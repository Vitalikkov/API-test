using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_test
{

    public partial class Temperatures
    {
        public string? cod { get; set; }
        public int? message { get; set; }
        public int? cnt { get; set; }
        public IList<WeatherList>? list { get; set; }
        public City? city { get; set; }
    }

    public partial class City
    {
        public long? id { get; set; }
        public string? name { get; set; }
        public Coord? coord { get; set; }
        public string? country { get; set; }
        public long? population { get; set; }
        public long? timezone { get; set; }
        public long? sunrise { get; set; }
        public long? sunset { get; set; }
    }

    public partial class Coord
    {
        public double? lat { get; set; }
        public double? lon { get; set; }
    }
    public partial class WeatherList
    {
        public long? dt { get; set; }
        public Main? main { get; set; }
        public long? visibility { get; set; }
        public double? pop { get; set; }
        public string? dt_txt { get; set; }
    }

    public partial class Main
    {
        public double? temp { get; set; }
        public double? feelsLike { get; set; }
        public double? tempMin { get; set; }
        public double? tempMax { get; set; }
        public long? pressure { get; set; }
        public long? deaLevel { get; set; }
        public long? grndLevel { get; set; }
        public long? humidity { get; set; }
        public double? tempKf { get; set; }
    }

    public partial class Sys
    {
        public string pod { get; set; }
    }

   
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://api.openweathermap.org/data/2.5/forecast?lat=49.427252469872386&lon=32.067075661057416&appid=ba80748e437221ce1381e94c85b66f48&units=metric&cnt=5";

        async static Task Main(string[] args)
        {
            await getWeather();
            Console.WriteLine("Hello, World!");

            async Task getWeather()
            {
                Console.WriteLine("Getting JSON...");
                var responseString = await client.GetStringAsync(url);
                Console.WriteLine("Parsing JSON...");
                Temperatures? weather =
                   JsonSerializer.Deserialize<Temperatures>(responseString);
                Console.WriteLine($"cod: {weather?.cod}");
                Console.WriteLine($"City: {weather?.city?.name}");
                Console.WriteLine($"population: {weather?.city?.population}");
                foreach (var el in weather?.list)
                {
                    Console.WriteLine($"Data : {el?.dt_txt}");
                    Console.WriteLine($"weather temp : {el?.main?.temp}");
                }
            }
        }
    }
}
