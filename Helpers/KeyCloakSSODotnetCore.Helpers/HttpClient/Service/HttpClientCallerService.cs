using KeyCloakSSODotnetCore.Helpers.HttpClient.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.HttpClient.Service
{
    public class HttpClientCallerService
    {
        IHttpClientCaller _httpClientCaller { get; set; }
        public HttpClientCallerService(IHttpClientCaller httpClientCaller)
        {
            _httpClientCaller = httpClientCaller;
        }

        public string GET(string url, Dictionary<string, string> httpHeaders, string contentType)
        {
            return _httpClientCaller.GET(url, httpHeaders, contentType);
        }

        public string POST(string url, string requestBody, string contentType)
        {
            return _httpClientCaller.POST(url, requestBody, contentType);
        }

        public string POST(string url, string requestBody, Dictionary<string, string> httpHeaders, string contentType)
        {
            return _httpClientCaller.POST(url, requestBody, httpHeaders, contentType);
        }

    }
}
