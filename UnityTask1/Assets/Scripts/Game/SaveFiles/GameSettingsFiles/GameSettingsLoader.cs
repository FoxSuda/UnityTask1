using System;
using Task1.FilesManagment;
using Task1.Settings;
using UnityEngine;

public class GameSettingsLoader : MonoBehaviour
{
    private IFileDownloader fileDownloader;
    private IFileUploader<GameSettings> fileUploader;

    public GameSettingsLoader(IFileDownloader fileDownloader, IFileUploader<GameSettings> fileUploader)
    {
        this.fileDownloader = fileDownloader;
        this.fileUploader = fileUploader;
    }

    public GameSettingsLoader()
    {
        fileDownloader = new LocalFileDownloader();
        fileUploader = new LocalFileUploader<GameSettings>();
    }

    public void DownloadSettings(string path, Action<GameSettings> onLoaded)
    {
        fileDownloader.DownloadFile(path, onLoaded);
    }

    public void UploadSettings(string path, GameSettings gameSettings)
    {
        fileUploader.UploadFile(path, gameSettings);
    }
}
