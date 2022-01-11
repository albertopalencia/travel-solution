// Alberto Segundo Palencia Benedetty

using System.Net;
using System.Net.Sockets;

namespace Identity.Helpers
{
    public class IpHelper
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipAddress in host.AddressList)
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                    return ipAddress.ToString();

            return string.Empty;
        }
    }
}