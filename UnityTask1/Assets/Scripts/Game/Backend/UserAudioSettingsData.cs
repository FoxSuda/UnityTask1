using Firebase.Firestore;

[FirestoreData]
public class UserAudioSettingsData
{
    public float UserMasterVolume;
    public float UsersfxVolume;
    public float UserMusicVolume;
    public bool UserMasterVolumeMute;
    public bool UsersfxVolumeMute;
    public bool UserMusicVolumeMute;

    [FirestoreProperty]
    public float userMasterVolume {  get; set; }
    [FirestoreProperty]
    public float usersfxVolume { get; set; }
    [FirestoreProperty]
    public float userMusicVolume { get; set; }
    [FirestoreProperty]
    public bool userMasterVolumeMute { get; set; }
    [FirestoreProperty]
    public bool usersfxVolumeMute { get; set; }
    [FirestoreProperty]
    public bool userMusicVolumeMute { get; set; }
}