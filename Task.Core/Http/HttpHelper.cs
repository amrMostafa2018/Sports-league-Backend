using Microsoft.AspNetCore.Http;
using System.Net;

namespace Task.Core.Http
{
    public class HttpHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current => _httpContextAccessor.HttpContext;
        public static HostString Host => _httpContextAccessor.HttpContext.Request.Host;
        public static IFormCollection Form => _httpContextAccessor.HttpContext.Request.Form;
        public static IFormFileCollection Files => _httpContextAccessor.HttpContext.Request.Form.Files;
        public static IPAddress RemoteIpAddress => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
    }
}
