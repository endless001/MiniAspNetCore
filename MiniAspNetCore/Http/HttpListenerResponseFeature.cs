using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace MiniAspNetCore.Http
{
   public class HttpListenerResponseFeature : IResponseFeature
    {
        private readonly HttpListenerResponse _response;

        public HttpListenerResponseFeature(HttpListenerContext httpListenerContext)
        {
            _response = httpListenerContext.Response;
        }

        public int StatusCode 
        { 
            get => _response.StatusCode;
            set => _response.StatusCode = value;
        }

        public NameValueCollection Headers
        {
            get => _response.Headers;
            set
            {
                _response.Headers = new WebHeaderCollection();
                foreach (var key in value.AllKeys)
                    _response.Headers.Add(key, value[key]);
            }
        }

        public Stream Body => _response.OutputStream;
    }
}
