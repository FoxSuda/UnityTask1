using Task1.Settings;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsManager : MonoBehaviour
{
    private GameSettingsLoader settingsLoader;

    [SerializeField] private SoundButton masterVolumeMuted;
    [SerializeField] private SoundButton sfxVolumeMuted;
    [SerializeField] private SoundButton musicVolumeMuted;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    private void Awake()
    {
        settingsLoader = new GameSettingsLoader();
        LoadSettings();
    }

    private void OnApplicationQuit()
    {
        SaveSettings();
    }

    private void LoadSettings()
    {
        settingsLoader.DownloadSettings("", OnSettingsLoaded);
    }

    private void OnSettingsLoaded(GameSettings settings)
    {
        masterVolumeSlider.value = settings.SoundSettings.masterVolume;
        sfxVolumeSlider.value = settings.SoundSettings.sfxVolume;
        musicVolumeSlider.value = settings.SoundSettings.musicVolume;

        masterVolumeMuted.isMuted = settings.SoundSettings.masterVolumeMute;
        sfxVolumeMuted.isMuted = settings.SoundSettings.sfxVolumeMute;
        musicVolumeMuted.isMuted = settings.SoundSettings.musicVolumeMute;

        Debug.Log("Loaded settings: " + settings);
    }

    private void SaveSettings()
    {
        var settings = new GameSettings();
        settings.SoundSettings = new SoundSettings();

        settings.SoundSettings.masterVolume = masterVolumeSlider.value;
        settings.SoundSettings.sfxVolume = sfxVolumeSlider.value;
        settings.SoundSettings.musicVolume = musicVolumeSlider.value;

        settings.SoundSettings.masterVolumeMute = masterVolumeMuted.isMuted;
        settings.SoundSettings.sfxVolumeMute = sfxVolumeMuted.isMuted;
        settings.SoundSettings.musicVolumeMute = musicVolumeMuted.isMuted;

        settingsLoader.UploadSettings("", settings);
        Debug.Log("Settings saved.");
    }
}
