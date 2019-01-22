using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakDomain
{
    public class IntrospectTokenResponse
    {
        [JsonProperty("active")]
        public bool IsActive { get; set; }
    }
}
