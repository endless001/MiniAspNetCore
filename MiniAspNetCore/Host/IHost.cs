using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAspNetCore.Host
{
   public interface IHost
    {
        Task RunAsync(CancellationToken cancellationToken = default);
    }
}
