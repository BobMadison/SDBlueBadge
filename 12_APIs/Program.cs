using _12_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _12_APIs
{
    class Program
    {
        static void Main(string[] args)
        {
            SWAPIService service = new SWAPIService();
            SWAPIUI UI = new SWAPIUI(service);

            UI.Run();
            // HeyperText Transfer Protocol
            // HTML = HyperText Markup Language
            /*
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response =
                httpClient.GetAsync("https://swapi.dev/api/people/1/").Result;

            HttpResponseMessage planetResponse =
                            httpClient.GetAsync("https://swapi.dev/api/planets/1/").Result;
            // Async means it's happening asynchronously
            // (on another timeline)
            Person person = response.Content.ReadAsAsync<Person>().Result;
            if (response.IsSuccessStatusCode)
            {
                Planet planet = planetResponse.Content.ReadAsAsync<Planet>().Result;

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine($"\n\n{person.Name} is {person.Height} cm tall and has " +
                    $"{person.Eye_Color} eyes. {person.Name} is " +
                    $"from {person.HomeWorld}.");
            }

            if (planetResponse.IsSuccessStatusCode)
            {
                Planet planet = planetResponse.Content.ReadAsAsync<Planet>().Result;

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine($"\n\n{person.Name} is {person.Height} cm tall and has " +
                    $"{person.Eye_Color} eyes. {person.Name} is " +
                    $"from {person.HomeWorld}.");
            }
            

            */

        }
    }
}
