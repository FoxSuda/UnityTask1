using Task1.Player;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    private FirebaseGameBackendService firebaseGameBackendService = new();
    private DataBaseUserData _databaseUserData;
    private UserSettingsData _userSettingsData;

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameSettingsManager gameSettingsManager;

    private int _userCoins;

    private string userId = "player6";

    private void Awake()
    {
        playerStats.OnCoinsChanged += SaveUserCoins;
        firebaseGameBackendService.Initialize();
        firebaseGameBackendService.GetUserData(userId, LoadUser);
    }

    private DataBaseUserData CreateNewUser()
    {
        UserAudioSettingsData userData = new UserAudioSettingsData();
        userData.UserMasterVolume = 0.7f;
        userData.UsersfxVolume = 0.7f;
        userData.UserMusicVolume = 0.7f;

        userData.UserMasterVolumeMute = false;
        userData.UsersfxVolumeMute = false;
        userData.UserMusicVolumeMute = false;
        UserSettingsData userSettingsData = new UserSettingsData();
        userSettingsData.userAudioSettingsData = userData;
        DataBaseUserData dataBaseUserData = new(userId, 0, userSettingsData);
        return dataBaseUserData;
    }

    public void SaveUserSettings(UserSettingsData userSettingsData)
    {
        DataBaseUserData databaseUserData = new(userId, _userCoins, userSettingsData);

        _userSettingsData = userSettingsData;

        firebaseGameBackendService.CreateUser(databaseUserData);
    }

    public void SaveUserCoins()
    {
        DataBaseUserData databaseUserData = new(userId, playerStats.GetCoins(), _userSettingsData);

        _userCoins = playerStats.GetCoins();

        firebaseGameBackendService.CreateUser(databaseUserData);
    }

    public void LoadUser(DataBaseUserData databaseUserData)
    {
        if (databaseUserData != null)
        {
            _databaseUserData = databaseUserData;
            _userSettingsData = databaseUserData.UserSettingsData;
            playerStats.AddCoins(_databaseUserData.Coins_count);
            gameSettingsManager.OnSettingsLoadedData(_databaseUserData.UserSettingsData);
        } else
        {
            firebaseGameBackendService.CreateUser(CreateNewUser());
        }
    }
}
