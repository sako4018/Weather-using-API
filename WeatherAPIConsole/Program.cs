using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WeatherAPIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var client = new HttpClient();
                Console.WriteLine("Welcome to Open Weather API");
                Console.Write("Enter city name: ");
                var userEnterCity = Console.ReadLine().ToLower();
                var temperatureFromCity = $"https://api.openweathermap.org/data/2.5/weather?q={userEnterCity}&appid=96e52c99dde3c0e49fdeca1acfcba226&units=metric";
                var getWeather = client.GetStringAsync(temperatureFromCity).Result;

                JsonDocument doc = JsonDocument.Parse(getWeather);
                var temp = doc.RootElement
                     .GetProperty("main")
                     .GetProperty("temp")
                     .GetDouble();

                Console.WriteLine($"{temp} °C");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
