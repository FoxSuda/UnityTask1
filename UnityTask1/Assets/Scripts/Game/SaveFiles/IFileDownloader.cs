using System;

namespace Task1.FilesManagment
{
    public interface IFileDownloader
    {
        public void DownloadFile<T>(string path, Action<T> onFileDownloaded);
    }
}

