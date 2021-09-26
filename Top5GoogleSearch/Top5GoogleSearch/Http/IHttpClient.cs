using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Top5GoogleSearch.Models;

namespace Top5GoogleSearch.Http
{
    public interface IHttpClient
    {
        public Task<string> GetTop5GoogleSearch(string apiKey,string query);
    }
}
