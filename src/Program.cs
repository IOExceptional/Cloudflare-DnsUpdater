using System;
using System.Threading.Tasks;
using IOExceptional.DnsUpdater.Cloudflare;

namespace IOExceptional.DnsUpdater
{
    class Program
    {

        static void Main(string[] args)
        {
            Run(args).GetAwaiter().GetResult();
        }

        static async Task Run(string[] args)
        {
            var ip = await IpRetriever.GetIp();

            if(string.IsNullOrEmpty(ip))
            {
                Console.WriteLine("Error, ip was not retrieved");
                return;
            }

            Console.WriteLine($"IP is: {ip}");

            await SetDnsEntry(new DnsSettings
            {
                Email = args[0],
                ApiKey = args[1],

                ZoneId = args[2],
                ZoneName = args[3],

                RecordId = args[4],
                RecordName = args[5],

                Value = ip
            });
        }

        static async Task SetDnsEntry(DnsSettings settings)
        {
            var cloudflareClient = new CloudflareClient(settings.Email, settings.ApiKey);


            try
            {
                await cloudflareClient.SetDnsRecord(settings.ZoneId, settings.RecordId, settings.RecordType, $"{settings.RecordName}.{settings.ZoneName}", settings.Value);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        private class DnsSettings
        {
            public string Email { get; set; }
            public string ApiKey { get; set; }

            public string ZoneName { get; set; }
            public string ZoneId { get; set; }

            public string RecordName { get; set; }
            public string RecordId { get; set; }

            public string RecordType { get; set; } = "A";
            public string Value { get; set; }
        }
    }
}
