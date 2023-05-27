using System.IO;

namespace Task.Core.Domains
{
    public static class HostUrl
    {
        public static string _urlBackEnd;

        public static string BackEnd()
        {
            return _urlBackEnd;
        }

        public static string BackEnd(string url)
        {
            return Path.Combine(_urlBackEnd, url);
        }

    }
}