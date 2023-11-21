using System;
using System.IO;
using UnityEngine;

namespace Task1.FilesManagment
{
    public class LocalFileDownloader : IFileDownloader
    {
        public void DownloadFile<T>(string path, Action<T> onFileDownloaded)
        {
            try
            {
                string filePath = GetFilePath("clientData.json");

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string json = reader.ReadToEnd();
                        T downloadedFile = JsonUtility.FromJson<T>(json);
                        onFileDownloaded?.Invoke(downloadedFile);
                    }
                }
                else
                {
                    Debug.LogError("File not found: " + filePath);
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error downloading file: " + e.Message);
            }
        }

        private string GetFilePath(string fileName)
        {
            string filePath = Application.persistentDataPath + "/" + fileName;
            return filePath;
        }
    }
}

