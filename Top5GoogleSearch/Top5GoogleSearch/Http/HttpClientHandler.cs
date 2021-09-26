using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Top5GoogleSearch.Models;

namespace Top5GoogleSearch.Http
{
    public class HttpClientHandler:IHttpClient
    {
        private System.Net.Http.HttpClient _client;
        public HttpClientHandler(System.Net.Http.HttpClient client)
        {
            _client = client;
        }

        public Task<string> GetTop5GoogleSearch(string apiKey, string query)
        {
            string url = "https://api.goog.io/v1/search/q="+ query +"?apikey=" + apiKey;
            return  _client.GetStringAsync(url);
        }
    }
}
