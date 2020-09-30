﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAspNetCore.Http
{
   public class HttpContext
    {
        public IServiceProvider RequestServices { get; set; }

        public HttpRequest Request { get; set; }

        public HttpResponse Response { get; set; }

        public IFeatureCollection Features { get; set; }

        public HttpContext(IFeatureCollection featureCollection)
        {
            Features = featureCollection;
            Request = new HttpRequest(featureCollection);
            Response = new HttpResponse(featureCollection);
        }
    }
}
