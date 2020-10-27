using System.Collections.Generic;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public interface FileFolderSearcherDao
    {
        /// <summary>
        /// Searches for files and folders where the name contains the query. The search is 
        /// started from the root of the partition with the program running.
        /// </summary>
        /// <param name="query">The query for the search.</param>
        /// <returns>List of FileFolderSearchResult object each representing a file or a folder.</returns>
         List<FileFolderSearchResult> FileFolderSearcher(string query);
    }
}