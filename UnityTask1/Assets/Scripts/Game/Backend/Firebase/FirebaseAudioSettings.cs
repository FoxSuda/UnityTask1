using Firebase.Firestore;

[FirestoreData]
public class FirebaseAudioSettings
{
    [FirestoreProperty]
    public float UserMasterVolume { get; set; }
    [FirestoreProperty]
    public float UsersfxVolume { get; set; }
    [FirestoreProperty]
    public float UserMusicVolume { get; set; }
    [FirestoreProperty]
    public bool UserMasterVolumeMute { get; set; }
    [FirestoreProperty]
    public bool UsersfxVolumeMute { get; set; }
    [FirestoreProperty]
    public bool UserMusicVolumeMute { get; set; }
}
