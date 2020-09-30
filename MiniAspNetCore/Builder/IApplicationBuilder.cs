using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAspNetCore.Builder
{
    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);

        RequestDelegate Build();

        IApplicationBuilder New();
    }
}
