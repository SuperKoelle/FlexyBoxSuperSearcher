using System.IO;

namespace FlexyBoxSuperSearcher.FileFolderSearcher
{
    public class FileFolderSeacher
    {
        private FileInfo fileInfo;

        public FileFolderSeacher(string fileInfo)
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