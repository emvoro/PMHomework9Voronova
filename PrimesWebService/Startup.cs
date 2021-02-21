using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using PrimesWebService.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace PrimesWebService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPrimesOperation, PrimesOperation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var logger = context.RequestServices.GetService<ILogger<Startup>>();
                    logger.LogInformation("Application information requested.");
                    await context.Response.WriteAsync(" Primes app by PMA student Voronova Emilia");
                    logger.LogInformation("Application information is: \"Primes app by PMA student Voronova Emilia\"");
                });

                endpoints.MapGet("/primes", async context =>
                {
                    var logger = context.RequestServices.GetService<ILogger<Startup>>();
                    try
                    {
                        var primesOperation = context.RequestServices.GetService<IPrimesOperation>();
                        logger.LogInformation("Primes in range requested.");
                        var from = int.Parse(context.Request.Query["from"].FirstOrDefault());
                        var to = int.Parse(context.Request.Query["to"].FirstOrDefault());
                        logger.LogInformation($"Primes in diapason {from} - {to} requested.");
                        var primes = await primesOperation.GetPrimes(from, to);
                        var responce = string.Join(',', primes);
                        logger.LogInformation($"{context.Response.StatusCode}. Primes in range {from} - {to} are : [{responce}]");
                        await context.Response.WriteAsync($"{context.Response.StatusCode} \"{responce}\".");
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogInformation($"{context.Response.StatusCode} Bad Request.");
                        await context.Response.WriteAsync($"{context.Response.StatusCode} \"{ex.Message}\"");
                    }
                });

                endpoints.MapGet("/primes/{number:int}", async context =>
                {
                    var logger = context.RequestServices.GetService<ILogger<Startup>>();
                    try
                    {
                        var primesOperation = context.RequestServices.GetService<IPrimesOperation>();
                        logger.LogInformation("Prime number check requested.");
                        var number = int.Parse((string)context.Request.RouteValues["number"]);
                        var responce = await primesOperation.IsPrime(number);
                        context.Response.StatusCode = responce ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
                        var log = context.Response.StatusCode == (int)(HttpStatusCode.OK) ? "is prime" : "is not prime";
                        logger.LogInformation($"{context.Response.StatusCode}. {number} {log}.");
                        await context.Response.WriteAsync($"{context.Response.StatusCode}.");
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        logger.LogInformation($"{context.Response.StatusCode} Bad Request.");
                        await context.Response.WriteAsync($"{context.Response.StatusCode} \"{ex.Message}\"");
                    }
                });
            });  
        }
    }
}
