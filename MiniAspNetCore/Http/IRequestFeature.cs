using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace MiniAspNetCore.Http
{
   public interface IRequestFeature
    {
        Uri Url { get; }

        string Method { get; }

        NameValueCollection Headers { get; }

        Stream Body { get; }
    }
}
