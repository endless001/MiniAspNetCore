using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAspNetCore.Builder;
using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAspNetCore.Host
{
    public interface IHostBuilder
    {
        IHostBuilder ConfigureConfiguration(Action<IConfigurationBuilder> configAction);

        IHostBuilder ConfigureServices(Action<IConfiguration, IServiceCollection> configureAction);

        IHostBuilder Initialize(Action<IConfiguration, IServiceProvider> initAction);

        IHostBuilder ConfigureApplication(Action<IConfiguration, IApplicationBuilder> configureAction);

        IHost Build();
    }
}
