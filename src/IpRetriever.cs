using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IOExceptional.DnsUpdater
{
    internal static class IpRetriever
    {
        const string IpRetrievalUri = "https://ipinfo.io/ip";

        internal static async Task<string> GetIp()
        {
            using (var client = new HttpClient())
            {
                using (var res = await client.GetAsync(IpRetrievalUri))
                {
                    using (var content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data.Replace("\n", "");
                        }
                        return null;
                    }
                }
            }
        }
    }
}
