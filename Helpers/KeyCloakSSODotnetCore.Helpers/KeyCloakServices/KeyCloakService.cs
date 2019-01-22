using KeyCloakSSODotnetCore.Helpers.HttpClient.Implementation;
using KeyCloakSSODotnetCore.Helpers.HttpClient.Service;
using KeyCloakSSODotnetCore.Helpers.KeyCloakDomain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakServices
{
    public static class KeyCloakService
    {

        public static AccessTokenResponse GetAccessToken(KeyCloakOAuthAPIConfig keyCloakServerOptions)
        {
            string accessTokenJson = new HttpClientCallerService(new DefaultHttpClientCaller()).POST(keyCloakServerOptions.AccessTokenEndpoint, string.Format("grant_type={0}&client_id={1}&client_secret={2}", keyCloakServerOptions.Grant_Type, keyCloakServerOptions.Client_Id, keyCloakServerOptions.Client_Secret), "application/x-www-form-urlencoded");
            return JsonConvert.DeserializeObject<AccessTokenResponse>(accessTokenJson);
        }


        public static IntrospectTokenResponse IntrospectAccessToken(KeyCloakOAuthClientConfig keyCloakClientOption,string token)
        {
            string introspectTokenJson = new HttpClientCallerService(new DefaultHttpClientCaller()).POST(keyCloakClientOption.TokenIntrospectEndpoint, string.Format("token={0}&client_id={1}&client_secret={2}", token, keyCloakClientOption.Client_Id,keyCloakClientOption.Client_Secret), "application/x-www-form-urlencoded");
            return JsonConvert.DeserializeObject<IntrospectTokenResponse>(introspectTokenJson);
        }
    }
}
