using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public class FileFolderSearcherImpl : FileFolderSearcherDao
    {
        public List<FileFolderSeacher> FileFolderSearcher(string query)
        {
            var task = Task.Run<List<string>>(async () => await FileFolderSearcherAsync(query));
            // Parser kunne måske laves som Linq
            return Parser(task.Result).ToList();
        }

        private async static Task<List<string>> FileFolderSearcherAsync(string query)
        {
            var result = new List<string>();
            var rootPath = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory); // Kun tested på Mac

            void InnerMethod(string path)
            {
                query = "*" + query + "*";
                result.AddRange(Directory.GetFiles(path, query + ".*", SearchOption.TopDirectoryOnly)); // Søger ikke efter filtyper
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

        private static IEnumerable<FileFolderSeacher> Parser(IEnumerable<string> input)
        {
            var result = new List<FileFolderSeacher>();

            foreach (var item in input)
            {
                result.Add(new FileFolderSeacher(item));
            }

            return result;
        }
    }
}