namespace WeatherApp_CSharp
{
    public class WeatherInfo
    {
        public class Coords
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Weather
        {
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class MainInfo
        {
            public double Temp { get; set; }
            public double Pressure { get; set; }
            public double Humidity { get; set; }
            public double FeelsLike { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
        }

        public class Sys
        {
            public long Sunset { get; set; }
            public long Sunrise { get; set; }
        }

        public class Root
        {
            public Coords Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public MainInfo Main { get; set; }
            public Wind Wind { get; set; }
            public Sys Sys { get; set; }
        }

    }
}