using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;


namespace CurrentWeatherForecast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your Zip Code?");
            var zipCode = Console.ReadLine();

            //Console.WriteLine("What is the API Key?");
            //var API_key = Console.ReadLine();

            var API_key = "04e1b49f8eaa85823821052ace1a653f";
            var client = new HttpClient();
            var WeatherURL = ($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},&appid={API_key}&units=imperial");
            var Response = client.GetStringAsync(WeatherURL).Result;
            var tempInFahrenheit = JObject.Parse(Response).GetValue("main").ToString();
            Console.WriteLine($"The Weather at {zipCode} is '{tempInFahrenheit}'\n");


        }
    }
}
