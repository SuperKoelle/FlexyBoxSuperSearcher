using System.Collections.Generic;

namespace FlexyBoxSuperSearcher.InternetSearcher
{
    public interface InternetSearcherDao
    {
        InternetSearchResult InternetSearcher(string query);
    }
}