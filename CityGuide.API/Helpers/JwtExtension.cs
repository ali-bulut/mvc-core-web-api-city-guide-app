using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CityGuide.API.Helpers
{
    //extension methodun static olması gerekir!
    public static class JwtExtension
    {
        //burada this keywordü methodun extension olduğunu söyler.
        //Kullanımı ise;
        //HttpResponse response=new HttpResponse();
        //response.AddApplicationError("test");
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
        }
    }
}
