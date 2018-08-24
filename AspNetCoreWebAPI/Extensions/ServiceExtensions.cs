using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Extensions
{
    public static  class ServiceExtensions
    {
        /*
         * CORS : Cross Origin Resource Sharing is a mechanism that gives rights to users to access resources from the server on a different domain.
         *        Because we will use Angular (or any other client side framework or any other client) on a different domain than server's domain
         *        configuring CORS is mandatory.
         */ 
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });
        }

        /*
         * you can restrict the CORS domains, methods and headers as in the following method, so that it will give you higher security  
         */
        public static void ConfigureCorsRestricted(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicyRestricted",
                      builder => builder.WithOrigins("http://www.somedomainname.com")
                                        .WithMethods("POST", "GET")
                                        .WithHeaders("accept", "content-type"));

            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}
