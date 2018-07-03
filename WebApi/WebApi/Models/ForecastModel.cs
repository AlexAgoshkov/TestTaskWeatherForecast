using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /*http://json2csharp.com*/
    public class MainForecast
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class ForecastWeathers
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class CloudsForecast
    {
        public int all { get; set; }
    }

    public class WindForecast
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class SysForecast
    {
        public string pod { get; set; }
    }

    public class ListForecast
    {
        public int dt { get; set; }
        public MainForecast main { get; set; }
        public List<ForecastWeathers> weather { get; set; }
        public CloudsForecast clouds { get; set; }
        public WindForecast wind { get; set; }
        public SysForecast sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class CoordForecast
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class CityForecast
    {
        public int id { get; set; }
        public string name { get; set; }
        public CoordForecast coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class RootObject
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ListForecast> list { get; set; }
        public CityForecast city { get; set; }
    }
}