using MiniAspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniAspNetCore.Builder
{


    public class ApplicationBuilder : IApplicationBuilder
    {

        private readonly RequestDelegate _completeFunc;
        private readonly IList<Func<RequestDelegate, RequestDelegate>> _pipelines = new List<Func<RequestDelegate,RequestDelegate>>();
        public static IApplicationBuilder Create(RequestDelegate completeAction)
        {
            return new ApplicationBuilder(completeAction);
        }

      
        public ApplicationBuilder(RequestDelegate completeFunc)
        {
            _completeFunc = completeFunc;
        }

        public RequestDelegate Build()
        {

            var request = _completeFunc;
            foreach (var pipeline in _pipelines.Reverse())
            {
                request = pipeline(request);
            }
            return request;

        }

        public IApplicationBuilder New()
        {
            throw new NotImplementedException();
           
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _pipelines.Add(middleware);
            return this;
        }
    }
}
