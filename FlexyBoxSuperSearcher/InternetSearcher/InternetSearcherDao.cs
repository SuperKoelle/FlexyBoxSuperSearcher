namespace FlexyBoxSuperSearcher.WeatherSearcher
{
    public interface WeatherSearcherDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        WeatherSearchResult WeatherSearcher(string query);
    }
}