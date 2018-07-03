using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi.Models
{
    public class WeatherForecast
    {
        public List<string> GetWeatherForFiveDays(string city, string appid, string type)
        {
            List<string> forecast = new List<string>();
          
            appid = "1bb6ee2cddff58ee3da8c24b28824471";
            type = "forecast";

            string apiResponse = GetLink(city, appid, type);

            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(apiResponse);

            string maxTemp = "";
            string minTemp = "";
            string speed = "";

            int daycount = 1;
            foreach (var item in rootObject.list)
            {

                maxTemp += " (Day) : " + daycount + " - " + item.main.temp_max + " ";
                minTemp += " (Day) : " + daycount + " - " + item.main.temp_min + " ";
                speed += " (Day) : " + daycount + " - " + item.wind.speed + " ";

                daycount++;
                if (daycount >= 6)
                {
                    break;
                }
            }

            forecast.Add(rootObject.list[1].dt_txt);
            forecast.Add(maxTemp);
            forecast.Add(minTemp);
            forecast.Add(speed);

            return forecast;
        }

        public List<string> GetWeatherForOneDay(string city, string appid, string type)
        {
            List<string> weather = new List<string>();

            string apiResponse = GetLink(city, appid, type);

            ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);

            string s = "\"/Date(" + rootObject.sys.sunset + ")/\"";
            var d = JsonConvert.DeserializeObject<DateTime>(s);

            weather.Add(d.ToString());
            weather.Add(rootObject.main.temp_max.ToString());
            weather.Add(rootObject.main.temp_min.ToString());
            weather.Add(rootObject.wind.speed.ToString());
            weather.Add(rootObject.weather[0].description);

            return weather;
        }



        private string GetLink(string city, string appid, string type)
        {
            HttpWebRequest apiRequest = WebRequest.Create
           ("http://api.openweathermap.org/data/2.5/" + type + "?q=" + city + "&appid=" + appid + "&units=metric")
            as HttpWebRequest;
            string apiResponse = "";

            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd().Trim();
            }

            return apiResponse;
        }
    }
}