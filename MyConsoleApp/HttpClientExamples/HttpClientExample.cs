using MyConsoleApp.EFCoreExamples;
using MyConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await ReadJsonPlaceHolder();
        }

        private async Task Read()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5244/api/Blog");
            
            if(response.IsSuccessStatusCode)
            {
                string JsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JsonStr);

                //JsonConvert.SerializeObject()
                //JsonConvert.DeserializeObject()

                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(JsonStr)!;

                foreach (BlogModel item in list)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        private async Task ReadJsonPlaceHolder()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                string JsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JsonStr);

                //JsonConvert.SerializeObject()
                //JsonConvert.DeserializeObject()

                List<JsonPlaceHolderModel> list = JsonConvert.DeserializeObject<List<JsonPlaceHolderModel>>(JsonStr)!;

                foreach (JsonPlaceHolderModel item in list)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                }
            }
        }
    }
}
