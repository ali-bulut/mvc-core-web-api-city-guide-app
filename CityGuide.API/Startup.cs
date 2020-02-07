using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CityGuide.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CityGuide.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //IConfiguration interface'i ile appsettings.json'a ulaþabiliriz.
        public IConfiguration Configuration { get; }

        //injection alaný (dependency injection)
        public void ConfigureServices(IServiceCollection services)
        {
            //anahtar appsettings.json'da tanýmlandý. Oradan value'sini çaðýrdýk.
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);

            //appsettings.json'da oluþturduðumuz connectionstringi projeye ekleme
            services.AddDbContext<DataContext>(p =>
                p.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //automapper'i projemize ekledik.
            services.AddAutoMapper(typeof(Startup));


            //nuget'tan Microsoft.AspNetCore.Mvc.NewtonsoftJson bunu eklememiz lazým
            //bunu eklememizin sebebi tablolar arasýnda geçiþse sonsuz döngü olursa ona aldýrma ve döngüye
            //girme diyoruz.
            services.AddControllers().AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            //Cors Konfigürasyonunu projeye ekledik. Bu sayede baþka bir projede apimizden gelen formatlarý almak
            //için istekte bulunulduðunda bunu onaylayacaðýz.
            services.AddCors();

            services.AddScoped<IAppRepository, AppRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //tokena baþkalarý eriþemesin diye içine kendi anahtarýmýzý koyarýz
                    ValidateIssuerSigningKey = true,
                    //kendi anahtarýmýzý verdik.
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //istek hangi header'dan hangi methodtan(get-post gibi) nereden gelirse gelsin tüm istekleri onayla.
            app.UseCors(p=>p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
