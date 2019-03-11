namespace IOExceptional.DnsUpdater.Cloudflare
{
    public class ResponseResult
    {
        public ResponseResult()
        {

        }

        public object Result { get; set; }

        public bool Success { get; set; }

        public string[] Errors { get; set; }

        public string[] Messages { get; set; }
    }
}