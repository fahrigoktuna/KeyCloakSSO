using KeyCloakSSODotnetCore.Helpers.HttpClient.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace KeyCloakSSODotnetCore.Helpers.HttpClient.Implementation
{
    public class DefaultHttpClientCaller : IHttpClientCaller
    {
        public string GET(string url, Dictionary<string, string> httpHeaders, string contentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";

            foreach (var item in httpHeaders)
                request.Headers.Add(item.Key, item.Value);

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string POST(string url, string requestBody, string contentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = requestBody;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string POST(string url, string requestBody, Dictionary<string, string> httpHeaders, string contentType)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            var postData = requestBody;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = data.Length;

            foreach (var item in httpHeaders)
                request.Headers.Add(item.Key, item.Value);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
