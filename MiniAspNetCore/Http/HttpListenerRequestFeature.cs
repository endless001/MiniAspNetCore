using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace MiniAspNetCore.Http
{
    public class HttpListenerRequestFeature: IRequestFeature
    {
        private readonly HttpListenerRequest _request;

        public HttpListenerRequestFeature(HttpListenerContext listenerContext)
        {
            _request = listenerContext.Request;
        }

        public Uri Url => _request.Url;
        public string Method => _request.HttpMethod;
        public NameValueCollection Headers => _request.Headers;
        public Stream Body => _request.InputStream;

    }

}
