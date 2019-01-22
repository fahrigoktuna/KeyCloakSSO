using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakDomain
{
    public class AccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
