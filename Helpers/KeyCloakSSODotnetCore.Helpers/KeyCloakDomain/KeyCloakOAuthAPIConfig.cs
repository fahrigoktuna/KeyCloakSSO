using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakDomain
{
    public class KeyCloakOAuthAPIConfig
    {
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
        public string Grant_Type { get; set; }
        public string AccessTokenEndpoint { get; set; }
    }
}
