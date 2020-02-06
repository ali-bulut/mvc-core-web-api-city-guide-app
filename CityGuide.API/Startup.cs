using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CityGuide.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //IConfiguration interface'i ile appsettings.json'a ula�abiliriz.
        public IConfiguration Configuration { get; }

        //injection alan� (dependency injection)
        public void ConfigureServices(IServiceCollection services)
        {
            //appsettings.json'da olu�turdu�umuz connectionstringi projeye ekleme
            services.AddDbContext<DataContext>(p =>
                p.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            //Cors Konfig�rasyonunu projeye ekledik. Bu sayede ba�ka bir projede apimizden gelen formatlar� almak
            //i�in istekte bulunuldu�unda bunu onaylayaca��z.
            services.AddCors();

            services.AddScoped<IAppRepository, AppRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //istek hangi header'dan hangi methodtan(get-post gibi) nereden gelirse gelsin t�m istekleri onayla.
            app.UseCors(p=>p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
