using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAspNetCore.Server
{
   public interface IServer
    {
        Task StartAsync(RequestDelegate requestDelegate, CancellationToken cancellationToken = default);
    }
}
