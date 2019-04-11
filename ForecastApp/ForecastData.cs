using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//Json.Net is used for json deserialization
namespace ForecastApp
{
    //The root of the Json
    class ForecastData
    { 
        [JsonProperty(PropertyName = "list")]
        public List<ForecastList> ForecastList { get; set; }
    }

    //Get to the list of forecasts (for a different days and time)
    class ForecastList
    {
        [JsonProperty(PropertyName = "main")]
        public MainInfo Main { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<Weather> Weather { get; set; }        
    }

    //Get the main information about weather (like temperature)
    class MainInfo
    {
        [JsonProperty(PropertyName = "temp_min")]
        public float Temp_min { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public float Temp_max { get; set; }
    }

    //Get the weather details (like Cleat, Rain, Clouds...)
    class Weather
    {
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }
    }
}
