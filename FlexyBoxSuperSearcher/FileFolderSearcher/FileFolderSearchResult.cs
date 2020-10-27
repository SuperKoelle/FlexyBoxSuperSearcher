using System.IO;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public class FileFolderSearchResult
    {
        private FileInfo fileInfo;

        public FileFolderSearchResult(string fileInfo)
        {
            this.fileInfo = new FileInfo(fileInfo);
        }
        public FileInfo FileInfo
        {
            get { return fileInfo; }
            set { fileInfo = value; }
        }
    }
}