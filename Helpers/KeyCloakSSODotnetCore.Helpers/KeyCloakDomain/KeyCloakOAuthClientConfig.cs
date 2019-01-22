using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakDomain
{
    public class KeyCloakOAuthClientConfig
    {
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
        public string TokenIntrospectEndpoint { get; set; }
    }
}
