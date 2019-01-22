using KeyCloakSSODotnetCore.Helpers.HttpClient.Implementation;
using KeyCloakSSODotnetCore.Helpers.HttpClient.Service;
using KeyCloakSSODotnetCore.Helpers.KeyCloakDomain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KeyCloakSSODotnetCore.Console
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Auth and get access token from auth server first.

            var authServerUrl = "http://localhost:5003/api/auth/login";

            var loginCredentials = new UserLogin() { Username = "kaan", Password = "kaan" };


            string loginCredJson = JsonConvert.SerializeObject(loginCredentials);


            string accessTokenResponse = new HttpClientCallerService(new DefaultHttpClientCaller()).POST(authServerUrl, loginCredJson, "application/json");


            AccessTokenResponse authResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(accessTokenResponse);

           


            Dictionary<string, string> httpHeaders = new Dictionary<string, string>()
            {
                {"Authorization","Bearer " + authResponse.AccessToken}
            };


            //Send same access token to ger response from WEB API1
            var client1Url = "http://localhost:5000/api/values";

            System.Console.WriteLine(new HttpClientCallerService(new DefaultHttpClientCaller()).GET(client1Url, httpHeaders, "application/json"));

            //Send same access token to ger response from WEB API2
            var client2Url = "http://localhost:5002/api/values";

            System.Console.WriteLine(new HttpClientCallerService(new DefaultHttpClientCaller()).GET(client2Url, httpHeaders, "application/json"));

            System.Console.Read();
        }


    }
}
