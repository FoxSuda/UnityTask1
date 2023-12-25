
using Firebase.Firestore;

[FirestoreData]
public class FirestoreUserData
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public int Coins_count { get; set; }
    [FirestoreProperty]
    public UserSettingsData UserSettingsData { get; set; }
}