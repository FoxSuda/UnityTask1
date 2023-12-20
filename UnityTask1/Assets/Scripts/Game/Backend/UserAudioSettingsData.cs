public class UserAudioSettingsData
{
    public float UserMasterVolume { get; }
    public float UsersfxVolume { get; }
    public float UserMusicVolume { get; }
    public bool UserMasterVolumeMute { get; }
    public bool UsersfxVolumeMute { get; }
    public bool UserMusicVolumeMute { get; }

    public UserAudioSettingsData(float userMasterVolume, float usersfxVolume, float userMusicVolume, bool userMasterVolumeMute, bool usersfxVolumeMute, bool userMusicVolumeMute)
    {
        UserMasterVolume = userMasterVolume;
        UsersfxVolume = usersfxVolume;
        UserMusicVolume = userMusicVolume;
        UserMasterVolumeMute = userMasterVolumeMute;
        UsersfxVolumeMute = usersfxVolumeMute;
        UserMusicVolumeMute = userMusicVolumeMute;
    }
}