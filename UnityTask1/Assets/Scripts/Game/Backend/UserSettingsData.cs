using Firebase.Firestore;

[FirestoreData]
public class UserSettingsData
{
    public UserAudioSettingsData UserAudioSettingsData;

    [FirestoreProperty]
    public UserAudioSettingsData userAudioSettingsData { get; set; }
}