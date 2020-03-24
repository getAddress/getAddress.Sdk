using System;


namespace getAddress.Sdk.Api
{
    public class AccessToken
    {
        
        public string Value { get; set; }

        public DateTime Expires { get; set; }
    }
    public class RefreshToken
    {
        public string Value { get; set; }

        public DateTime Expires { get; set; }

        public string Url { get; set; }
    }
}
