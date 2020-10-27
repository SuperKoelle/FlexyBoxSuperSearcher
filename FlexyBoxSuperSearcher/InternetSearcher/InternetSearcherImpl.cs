using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FlexyBoxSuperSearcher.WeatherSearcher
{
    public class WeatherSearcherImpl : WeatherSearcherDao
    {
         public WeatherSearchResult WeatherSearcher(string query)
         {
            var task = Task.Run<WeatherSearchResult>(async () => await WeatherSearcherAsync(query));
            return task.Result;
         }

        private static async Task<WeatherSearchResult> WeatherSearcherAsync(string query)
        {
            var weatherSearchResult = new WeatherSearchResult("");

            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://community-open-weather-map.p.rapidapi.com/")
                };

                httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "e61b689eb0msh6aa6a8181809045p1fbd89jsn943fccd9dc79");
                var response = await httpClient.GetAsync($"weather?q={query}&units=metric");
                var httpsResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JObject.Parse(httpsResponse);

                if (!jsonResponse.ContainsKey("message"))
                {
                    weatherSearchResult.Weather = jsonResponse["weather"][0]["main"].ToString() + ", " + jsonResponse["weather"][0]["description"].ToString();
                    weatherSearchResult.WindspeedMS = float.Parse(jsonResponse["wind"]["speed"].ToString());
                    weatherSearchResult.PlaceName = jsonResponse["name"].ToString() + ", " + jsonResponse["sys"]["country"].ToString();
                    weatherSearchResult.TemperatureCelcius = float.Parse(jsonResponse["main"]["temp"].ToString());
                }
                else
                {
                    weatherSearchResult.Message = "city not found";
                }
            }
            catch (Exception ex)
            {
                weatherSearchResult.Message = ex.Message;
            }

            return weatherSearchResult;
        }
    }
}