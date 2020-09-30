using Microsoft.Extensions.DependencyInjection;
using MiniAspNetCore.Host;
using MiniAspNetCore.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAspNetCore.Extensions
{
   public static class WebHostBuilderExtensions
    {
        public static IHostBuilder UseHttpListenerServer(this IHostBuilder builder)
        {
            return builder.ConfigureServices((configuration, services) =>
            {
                services.AddSingleton<IServer, HttpListenerServer>();
            });
        }
    }
}
