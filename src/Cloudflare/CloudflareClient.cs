using RestSharp;
using System.Threading.Tasks;

namespace IOExceptional.DnsUpdater.Cloudflare
{
    public class CloudflareClient
    {
        private RestClient _restClient;

        public CloudflareClient(string email, string apiKey, string baseUri = "https://api.cloudflare.com/client/v4/")
        {
            _restClient = new RestClient(baseUri);

            _restClient.AddDefaultHeader("X-Auth-Email", email);
            _restClient.AddDefaultHeader("X-Auth-Key", apiKey);
        }

        public async Task SetDnsRecord(string zoneId, string recordId, string type, string name, string content)
        {
            var request = new RestRequest($"zones/{zoneId}/dns_records/{recordId}");

            request.AddJsonBody(new
            {
                type,
                name,
                content
            });

            var response = await _restClient.PutAsync<ResponseResult>(request);
        }
    }
}
