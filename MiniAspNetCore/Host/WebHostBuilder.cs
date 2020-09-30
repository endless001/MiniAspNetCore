using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAspNetCore.Builder;
using MiniAspNetCore.Extensions;
using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniAspNetCore.Host
{
    public class WebHostBuilder : IHostBuilder
    {

        private readonly IConfigurationBuilder _configurationBuilder = new ConfigurationBuilder();
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();

        private Action<IConfiguration, IServiceProvider> _initAction = null;

        private readonly IApplicationBuilder _requestPipeline = ApplicationBuilder.Create(context =>
        {
            context.Response.StatusCode = 404;
            return Task.CompletedTask;
        });

        public IHost Build()
        {
            var configuration = _configurationBuilder.Build();
            _serviceCollection.AddSingleton<IConfiguration>(configuration);
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            _initAction?.Invoke(configuration, serviceProvider);

            return new WebHost(serviceProvider, _requestPipeline.Build());
        }

        public static WebHostBuilder CreateDefault(string[] args)
        {
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder
                .ConfigureConfiguration(builder => builder.AddJsonFile("appsettings.json", true, true))
                .UseHttpListenerServer();

            return webHostBuilder;
        }

        public IHostBuilder ConfigureApplication(Action<IConfiguration, IApplicationBuilder> configureAction)
        {
            if (null != configureAction)
            {
                var configuration = _configurationBuilder.Build();
                configureAction.Invoke(configuration, _requestPipeline);
            }
            return this;
        }

        public IHostBuilder ConfigureConfiguration(Action<IConfigurationBuilder> configAction)
        {
            configAction?.Invoke(_configurationBuilder);
            return this;
        }

        public IHostBuilder ConfigureServices(Action<IConfiguration, IServiceCollection> configureAction)
        {
            if (null != configureAction)
            {
                var configuration = _configurationBuilder.Build();
                configureAction.Invoke(configuration, _serviceCollection);
            }

            return this;
        }

        public IHostBuilder Initialize(Action<IConfiguration, IServiceProvider> initAction)
        {
            if (null != initAction)
            {
                _initAction = initAction;
            }

            return this;
        }
    }
}
