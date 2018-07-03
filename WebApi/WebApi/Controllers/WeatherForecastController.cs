using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        [Route("api/GetWeatherFiveDay")]
        public IHttpActionResult GetWeatherFiveDay(string city)
        {
            WeatherForecast oneDay = new WeatherForecast();

            StringBuilder sb = new StringBuilder();

            string appid = "1bb6ee2cddff58ee3da8c24b28824471";
            string type = "forecast";

            for (int i = 0; i < oneDay.GetWeatherForFiveDays(city, appid, type).Count; i++)
            {

                sb.Append(" Date -" + oneDay.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Max Temp " + oneDay.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Min Temp " + oneDay.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Speed " + oneDay.GetWeatherForFiveDays(city, appid, type)[i++]);

            }

            return Ok(sb.ToString().Replace('"', ' '));
        }

        [HttpGet]
        [Route("api/GetWeather")]
        public IHttpActionResult GetWeather(string city)
        {
            string appid = "1bb6ee2cddff58ee3da8c24b28824471";
            string type = "weather";

            WeatherForecast oneDay = new WeatherForecast();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < oneDay.GetWeatherForOneDay(city, appid, type).Count; i++)
            {
                sb.Append(" DateTime - " + oneDay.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Temp Max - " + oneDay.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Temp Min - " + oneDay.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Speed - " + oneDay.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Weather - " + oneDay.GetWeatherForOneDay(city, appid, type)[i++]);
            }

            return Ok(sb.ToString().Replace('"', ' '));
        }
    }
}
