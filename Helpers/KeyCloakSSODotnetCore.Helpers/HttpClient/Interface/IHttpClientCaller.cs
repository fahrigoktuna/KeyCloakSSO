using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.HttpClient.Interface
{
    public interface IHttpClientCaller
    {
        string POST(string url, string requestBody, string contentType);

        string POST(string url, string requestBody, Dictionary<string,string> httpHeaders, string contentType);

        string GET(string url, Dictionary<string, string> httpHeaders, string contentType);
    }
}
