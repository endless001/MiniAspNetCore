using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAspNetCore.Extensions;
using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAspNetCore.Server
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _listener;
        private readonly IServiceProvider _serviceProvider;

        public HttpListenerServer(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _listener = new HttpListener();
            var urls = configuration["ASPNETCORE_URLS"]?.Split(';');

            if (urls !=null && urls.Length >0)
            {
                foreach (var url in urls
                     .Where(u => !string.IsNullOrEmpty(u))
                     .Select(u => u.Trim())
                     .Distinct())
                {
                    _listener.Prefixes.Add(url.EndsWith("/") ? url : $"{url}/");
                }
            }
            else
            {
                _listener.Prefixes.Add("http://localhost:8000/");
            }
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(RequestDelegate requestHandler, CancellationToken cancellationToken = default)
        {
            _listener.Start();

            if (_listener.IsListening)
            {
                Console.WriteLine("the server is listening on ");
                Console.WriteLine(string.Join(",", _listener.Prefixes));
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                var listenerContext = await _listener.GetContextAsync();
                var featureCollection = new FeatureCollection();

                featureCollection.Set(listenerContext.GetRequestFeature());
                featureCollection.Set(listenerContext.GetResponseFeature());

                using (var scope = _serviceProvider.CreateScope())
                {
                    var httpContext = new HttpContext(featureCollection)
                    {
                        RequestServices = scope.ServiceProvider,
                    };

                    await requestHandler(httpContext);
                }
                listenerContext.Response.Close();
            }
            _listener.Stop();
        }
    }
}
