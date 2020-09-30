using MiniAspNetCore.Host;
using MiniAspNetCore.Extensions;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace MiniAspNetCore
{
    class Program
    {
        private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
        static async Task Main(string[] args)
        {
       

            var host = WebHostBuilder.CreateDefault(args)
                .ConfigureServices((configuration, services) =>
                {
                })
                .ConfigureApplication((configuration, app) =>
                {
                    
                    app
                        .Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync($"middleware2, requestPath:{context.Request.Url.AbsolutePath}");
                            await next();
                        })
                        .Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync($"middleware3, requestPath:{context.Request.Url.AbsolutePath}");
                            await next();
                        })
                        ;
                    //app.Run(context => context.Response.WriteAsync("Hello Mini Asp.Net Core"));
                })
                .Initialize((configuration, services) =>
                {
                })
                .Build();
            await host.RunAsync(Cts.Token);
        }
    }
}
