using System.Collections.Generic;

namespace System.Net.Helpers
{
    public static class EndpointHelper
    {
        public static (string, int) Split(this EndPoint endpoint)
        {
            string host;
            int port;

            switch (endpoint)
            {
                case DnsEndPoint dnsEndPoint:
                    host = dnsEndPoint.Host;
                    port = dnsEndPoint.Port;
                    break;
                case IPEndPoint ipEndPoint:
                    host = ipEndPoint.Address.ToString();
                    port = ipEndPoint.Port;
                    break;
                default:
                    throw new ArgumentException("Endpoint may be of type DnsEndPoint or IPEndPoint only");
            }

            return (host, port);
        }

        public static string ToSingleString(this IEnumerable<EndPoint> endpoints, string separator = ", ")
        {
            return string.Join("; ", endpoints);
        }
    }
}