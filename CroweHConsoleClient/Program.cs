using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CroweHConsoleClient
{
    class Program
    {
        //static void Main(string[] args)
        static void Main()
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49821/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/values");
                    response.EnsureSuccessStatusCode();
                    string message = await response.Content.ReadAsAsync<string>();
                    Console.WriteLine("{0}", message);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error on API call: {0}", e.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
