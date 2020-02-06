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

        //IConfiguration interface'i ile appsettings.json'a ulaşabiliriz.
        public IConfiguration Configuration { get; }

        //injection alanı (dependency injection)
        public void ConfigureServices(IServiceCollection services)
        {
            //appsettings.json'da oluşturduğumuz connectionstringi projeye ekleme
            services.AddDbContext<DataContext>(p =>
                p.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            //Cors Konfigürasyonunu projeye ekledik. Bu sayede başka bir projede apimizden gelen formatları almak
            //için istekte bulunulduğunda bunu onaylayacağız.
            services.AddCors();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
