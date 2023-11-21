using System.IO;
using Task1.FilesManagment;
using UnityEngine;

public class LocalFileUploader<T> : IFileUploader<T>
{
    public void UploadFile(string path, T File)
    {
        string json = JsonUtility.ToJson(File);
        string filePath = GetFilePath("clientData.json");
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.WriteLine(json);
        }

        Debug.Log(filePath);
    }

    private string GetFilePath(string fileName)
    {
        string logResultPath = Application.persistentDataPath + "/" + fileName;
        Debug.Log(logResultPath);
        return logResultPath;
    }
}
