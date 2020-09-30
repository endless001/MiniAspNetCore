using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MiniAspNetCore.Extensions
{
   public static class HttpListenerContextExtensions
    {
        public static IRequestFeature GetRequestFeature(this HttpListenerContext context)
        {
            return new HttpListenerRequestFeature(context);
        }
        public static IResponseFeature GetResponseFeature(this HttpListenerContext context)
        {
            return new HttpListenerResponseFeature(context);
        }
    }
}
