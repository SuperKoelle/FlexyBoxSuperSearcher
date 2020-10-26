namespace FlexyBoxSuperSearcher.InternetSearcher
{
    public class InternetSearchResult
    {
        private string weather;
        private string placeName;
        private float temperatureCelcius;
        private float windspeedMS;
        public InternetSearchResult(string weather, string placeName, float temperatureCelcius, float windspeedMS)
        {
            this.weather = weather;
            this.placeName = placeName;
            this.temperatureCelcius = temperatureCelcius;
            this.windspeedMS = windspeedMS;
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
    }
}