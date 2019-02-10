using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace System.Net.Helpers
{
    // ReSharper disable once UnusedMember.Global
    public static class NetworkInterfacesHelper
    {
        // ReSharper disable once UnusedMember.Global
        public static IEnumerable<IPAddress> GetIpAddresses(this IEnumerable<NetworkInterface> interfaces)
        {
            return interfaces
                .SelectMany(ni =>
                    ni
                        .GetIPProperties()
                        .UnicastAddresses
                        .Select(ua => ua.Address)
                        .Where(address => address.AddressFamily == AddressFamily.InterNetwork)
                );
        }

        // ReSharper disable once UnusedMember.Global
        public static IEnumerable<IPAddress> GetIpV6Addresses(this IEnumerable<NetworkInterface> interfaces)
        {
            return interfaces
                .SelectMany(ni =>
                    ni
                        .GetIPProperties()
                        .UnicastAddresses
                        .Select(ua => ua.Address)
                        .Where(address => address.AddressFamily == AddressFamily.InterNetworkV6)
                );
        }
    }
}