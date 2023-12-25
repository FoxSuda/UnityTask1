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

    [SerializeField] private Button saveSettingsButton;
    [SerializeField] private FirebaseManager firebaseController;

    private void Awake()
    {
        saveSettingsButton.onClick.AddListener(SaveGameSettings);
        settingsLoader = new GameSettingsLoader();
        LoadSettings();
    }

    private void OnDestroy()
    {
        saveSettingsButton.onClick.RemoveListener(SaveGameSettings);
    }

    private void SaveGameSettings()
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
    
    public void OnSettingsLoadedData(UserSettingsData settings)
    {
        masterVolumeSlider.value = settings.userAudioSettingsData.UserMasterVolume;
        sfxVolumeSlider.value = settings.userAudioSettingsData.UsersfxVolume;
        musicVolumeSlider.value = settings.userAudioSettingsData.UserMusicVolume;

        masterVolumeMuted.isMuted = settings.userAudioSettingsData.UserMasterVolumeMute;
        sfxVolumeMuted.isMuted = settings.userAudioSettingsData.UsersfxVolumeMute;
        musicVolumeMuted.isMuted = settings.userAudioSettingsData.UserMusicVolumeMute;

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

        UserAudioSettingsData userAudioSettingsData = new();
        userAudioSettingsData.UserMasterVolume = masterVolumeSlider.value;
        userAudioSettingsData.UsersfxVolume = sfxVolumeSlider.value;
        userAudioSettingsData.UserMusicVolume = musicVolumeSlider.value;

        userAudioSettingsData.UserMasterVolumeMute = masterVolumeMuted.isMuted;
        userAudioSettingsData.UsersfxVolumeMute = sfxVolumeMuted.isMuted;
        userAudioSettingsData.UserMusicVolumeMute = musicVolumeMuted.isMuted;

        UserSettingsData userSettingsData = new UserSettingsData();
        userSettingsData.userAudioSettingsData = userAudioSettingsData;

        firebaseController.SaveUserSettings(userSettingsData);
        settingsLoader.UploadSettings("", settings);
        Debug.Log("Settings saved.");
    }
}
