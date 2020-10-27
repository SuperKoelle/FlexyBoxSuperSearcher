namespace FlexyBoxSuperSearcher.WeatherSearcher
{
    public class WeatherSearchResult
    {
        private string weather;
        private string placeName;
        private float temperatureCelcius;
        private float windspeedMS;
        public WeatherSearchResult(string weather, string placeName, float temperatureCelcius, float windspeedMS)
        {
            this.weather = weather;
            this.placeName = placeName;
            this.temperatureCelcius = temperatureCelcius;
            this.windspeedMS = windspeedMS;
        }
        public WeatherSearchResult(string message)
        {
            this.message = message;
        }
        public float WindspeedMS
        {
            get { return windspeedMS; }
            set { windspeedMS = value; }
        }
        public float TemperatureCelcius
        {
            get { return temperatureCelcius; }
            set { temperatureCelcius = value; }
        }
        public string PlaceName
        {
            get { return placeName; }
            set { placeName = value; }
        }        
        public string Weather
        {
            get { return weather; }
            set { weather = value; }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
            
    }
}