using Microsoft.Extensions.DependencyInjection;
using MiniAspNetCore.Http;
using MiniAspNetCore.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAspNetCore.Host
{
    public class WebHost : IHost
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IServer _server;

        public WebHost(IServiceProvider serviceProvider, RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            _server = serviceProvider.GetRequiredService<IServer>();
        }
        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            await _server.StartAsync(_requestDelegate,cancellationToken).ConfigureAwait(false);
        }
    }
}
