using System.Net;

namespace Eflatun.Common
{
    /// <summary>
    /// Utilities for Networking.
    /// </summary>
    public static class NetworkUtils
    {
        /// <summary>
        /// Tries to open a web client to "http://www.example.com", if no errors or exceptions arises, returns true.
        /// </summary>
        /// <remarks> The "http://www.example.com" is an example domain provided by IANA. </remarks>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.example.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
