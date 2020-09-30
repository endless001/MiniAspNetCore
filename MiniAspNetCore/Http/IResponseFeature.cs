using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace MiniAspNetCore.Http
{
    public interface IResponseFeature
    {
        int StatusCode { get; set; }

        NameValueCollection Headers { get; set; }

        public Stream Body { get; }
    }
}
