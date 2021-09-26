using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Top5GoogleSearch.FileReader;
using Top5GoogleSearch.Http;
using Top5GoogleSearch.Models;

namespace Top5GoogleSearch
{
    public class App
    {
        private IFileReader _fileReader;
        private IHttpClient _httpClient;
        public App(IFileReader fileReader, IHttpClient httpClient)
        {
            _fileReader = fileReader;
            _httpClient = httpClient;
        }


        public async Task Run()
        {
            string file = _fileReader.ReadFile(@"C:\Users\shlomi.dery\OneDrive - 888Holdings\Desktop\top5.txt");
            string[] pharses = file.Split(";").Distinct().ToArray();
            string apiKey = "b868ddb3-993c-414e-9589-ea8f94097ab5";

            foreach (string phrase in pharses)
            {
                ThreadPool.QueueUserWorkItem(Process,new ThreadData(_httpClient,apiKey, phrase));
            }
            string userName = Console.ReadLine();
        }
        static void Process(object state)
        {
            ThreadData data = (ThreadData)state;
            Task<string> response = data._httpClient.GetTop5GoogleSearch(data._apiKey, data._phrase);
            JObject json = JObject.Parse(response.GetAwaiter().GetResult());
            JArray jArray = (JArray)json["results"];
            IList<GoogleSearchObject> googleSearchTitles = jArray.ToObject<IList<GoogleSearchObject>>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("(" +(i+1) +")" +"title "+ data._phrase + ":"+googleSearchTitles[i].title);
                Console.WriteLine("(" + (i+1) + ")" + "link " + data._phrase + ":" + googleSearchTitles[i].link);
                Console.WriteLine("(" + (i+1) + ")" + "description " + data._phrase + ":" + googleSearchTitles[i].description+"/n");
            }
        }
    }
}
