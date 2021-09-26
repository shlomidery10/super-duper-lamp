using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5GoogleSearch.Http;

namespace Top5GoogleSearch.Models
{
    public class ThreadData
    {
        public ThreadData(IHttpClient httpClient, string apiKey, string phrase)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _phrase = phrase;
        }

        public IHttpClient _httpClient { get; }
        public string _apiKey { get; }
        public string _phrase { get; }

    }
}
