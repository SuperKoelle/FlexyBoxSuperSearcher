using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FlexyBoxSuperSearcher.InternetSearcher
{
    public class InternetSearcherImpl : InternetSearcherDao
    {
         public InternetSearchResult InternetSearcher(string query)
         {
            var task = Task.Run<InternetSearchResult>(async () => await InternetSearcherAsync(query));
            return task.Result;
         }

        private static async Task<InternetSearchResult> InternetSearcherAsync(string query)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://community-open-weather-map.p.rapidapi.com/")
            };

            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "e61b689eb0msh6aa6a8181809045p1fbd89jsn943fccd9dc79");
            var response = await httpClient.GetAsync($"weather?q={query}&units=metric");
            var HttpsResponse = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(HttpsResponse);
            
            var internetSearchResult = new InternetSearchResult(
                jsonResponse["weather"][0]["main"].ToString() + ", " + jsonResponse["weather"][0]["description"].ToString(),
                jsonResponse["name"].ToString() + ", " + jsonResponse["sys"]["country"].ToString(),
                float.Parse(jsonResponse["main"]["temp"].ToString()),
                float.Parse(jsonResponse["wind"]["speed"].ToString())
            );

            return internetSearchResult;
        }
    }
}