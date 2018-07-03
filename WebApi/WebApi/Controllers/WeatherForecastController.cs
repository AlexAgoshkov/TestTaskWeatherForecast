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
            WeatherForecast wf = new WeatherForecast();

            StringBuilder sb = new StringBuilder();

            string appid = "1bb6ee2cddff58ee3da8c24b28824471";
            string type = "forecast";

            for (int i = 0; i < wf.GetWeatherForFiveDays(city, appid, type).Count; i++)
            {

                sb.Append(" Date -" + wf.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Max Temp " + wf.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Min Temp " + wf.GetWeatherForFiveDays(city, appid, type)[i++]);
                sb.Append(" Speed " + wf.GetWeatherForFiveDays(city, appid, type)[i++]);

            }

            return Ok(sb.ToString().Replace('"', ' '));
        }

        [HttpGet]
        [Route("api/GetWeather")]
        public IHttpActionResult GetWeather(string city)
        {
            string appid = "1bb6ee2cddff58ee3da8c24b28824471";
            string type = "weather";

            WeatherForecast wf = new WeatherForecast();
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < wf.GetWeatherForOneDay(city, appid, type).Count; i++)
            {
                sb.Append(" DateTime - " + wf.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Temp Max - " + wf.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Temp Min - " + wf.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Speed - " + wf.GetWeatherForOneDay(city, appid, type)[i++]);
                sb.Append(" Weather - " + wf.GetWeatherForOneDay(city, appid, type)[i++]);
            }

            return Ok(sb.ToString().Replace('"', ' '));
        }
    }
}
