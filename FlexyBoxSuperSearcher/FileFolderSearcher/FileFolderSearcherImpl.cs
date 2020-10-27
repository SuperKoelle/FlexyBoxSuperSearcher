using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public class FileFolderSearcherImpl : FileFolderSearcherDao
    {
        /// <summary>
        /// Searches for files and folders where the name contains the query. The search is 
        /// started from the root of the partition with the program running.
        /// </summary>
        /// <param name="query">The query for the search.</param>
        /// <returns>List of FileFolderSearchResult object each representing a file or a folder.</returns>
        public List<FileFolderSearchResult> FileFolderSearcher(string query)
        {
            var task = Task.Run<List<string>>(async () => await FileFolderSearcherAsync(query));
            return Parser(task.Result).ToList();
        }

        /// <summary>
        /// Searches for files and folders where the name contains the query. The search is 
        /// started from the root of the partition with the program running.
        /// </summary>
        /// <param name="query">The query for the search.</param>
        /// <returns>List of strings representing the name of the files and folders.</returns>
        private async static Task<List<string>> FileFolderSearcherAsync(string query)
        {
            var result = new List<string>();
            var rootPath = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);

            void InnerMethod(string path)
            {
                query = "*" + query + "*";
                result.AddRange(Directory.GetFiles(path, query + ".*", SearchOption.TopDirectoryOnly));
                var subFolders = Directory.GetDirectories(path, query, SearchOption.TopDirectoryOnly);
                result.AddRange(subFolders);

                foreach(var subFolder in subFolders)
                {
                    try
                    {
                        InnerMethod(subFolder);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        var t = ex;
                        // Eat it
                    }
                }   
            }

            var task = new Task(() => InnerMethod(rootPath));
            task.Start();
            await task;

            return result;
        }

        /// <summary>
        /// Parsing the strings of the collection to new FileFolderSearcher objects and return a collection of these.
        /// </summary>
        /// <param name="fileInfos">Collection with strings representing fileinformation.</param>
        /// <returns>Collection of FileFolderSeacher objects with fileinformation.</returns>
        private static IEnumerable<FileFolderSearchResult> Parser(IEnumerable<string> fileInfos)
        {
            var result = new List<FileFolderSearchResult>();

            foreach (var fileInfo in fileInfos)
            {
                result.Add(new FileFolderSearchResult(fileInfo));
            }

            return result;
        }
    }
}