using System.Collections.Generic;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public interface FileFolderSearcherDao
    {
         List<FileFolderSeacher> FileFolderSearcher(string query);
    }
}