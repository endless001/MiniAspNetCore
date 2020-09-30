using MiniAspNetCore.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace MiniAspNetCore.Http
{
    public class HttpResponse
    {
        private readonly IResponseFeature _responseFeature;

        public HttpResponse(IFeatureCollection featureCollection)
        {
            _responseFeature = featureCollection.Get<IResponseFeature>();
        }
        public bool ResponseStarted => _responseFeature.Body.Length > 0;


        public int StatusCode
        {
            get => _responseFeature.StatusCode;
            set => _responseFeature.StatusCode = value;
        }

        public async Task WriteAsync(byte[] responseBytes)
        {
            if (_responseFeature.StatusCode <= 0)
            {
                _responseFeature.StatusCode = 200;
            }
            if (responseBytes != null && responseBytes.Length > 0)
            {
                await _responseFeature.Body.WriteAsync(responseBytes);
            }
        }

        public async Task WriteAsync(string response)
        {
            if (_responseFeature.StatusCode <= 0)
            {
                _responseFeature.StatusCode = 200;
            }
            if (!string.IsNullOrEmpty(response))
            {
                await _responseFeature.Body.WriteAsync(Encoding.Default.GetBytes(response));
            }
        }
    }
}