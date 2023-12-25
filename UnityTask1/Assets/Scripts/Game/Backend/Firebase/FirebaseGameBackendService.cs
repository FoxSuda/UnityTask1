using System;
using UnityEngine;

public class FirebaseGameBackendService : IGameBackendService
{
    private IAuthService _authService;
    private IDataBaseService _dataBaseService;

    public void Initialize()
    {
        _authService = new FirebaseAuthService();
        _dataBaseService = new FirebaseDatabaseService();
    }

    public void Initialize(IAuthService authService, IDataBaseService dataBaseService)
    {
        _authService = authService;
        _dataBaseService = dataBaseService;
    }

    public void CreateUser(DataBaseUserData dataBaseUserData)
    {
        FirestoreUserData firestoreUserData = new FirestoreUserData();
        firestoreUserData.UserSettingsData = dataBaseUserData.UserSettingsData;
        firestoreUserData.UserSettingsData.userAudioSettingsData = dataBaseUserData.UserSettingsData.userAudioSettingsData;

        firestoreUserData.UserSettingsData.userAudioSettingsData.userMasterVolume = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UserMasterVolume;
        firestoreUserData.UserSettingsData.userAudioSettingsData.usersfxVolume = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UsersfxVolume;
        firestoreUserData.UserSettingsData.userAudioSettingsData.userMusicVolume = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UserMusicVolume;

        firestoreUserData.UserSettingsData.userAudioSettingsData.userMasterVolumeMute = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UserMasterVolumeMute;
        firestoreUserData.UserSettingsData.userAudioSettingsData.usersfxVolumeMute = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UsersfxVolumeMute;
        firestoreUserData.UserSettingsData.userAudioSettingsData.userMusicVolumeMute = 
            firestoreUserData.UserSettingsData.userAudioSettingsData.UserMusicVolumeMute;

        firestoreUserData.Id = dataBaseUserData.Id;
        firestoreUserData.Coins_count = dataBaseUserData.Coins_count;

        string userDocumentPath = firestoreUserData.Id;

        string path = string.Join(',', "users", userDocumentPath);
        DatabaseWriteRequestData<FirestoreUserData> databaseWriteRequestData = 
            new DatabaseWriteRequestData<FirestoreUserData>(path, firestoreUserData);

        _dataBaseService.CreateDocument<FirestoreUserData, ServerResponse>(databaseWriteRequestData, (response) =>
        {
            Debug.Log($"Response: {response.data.message}");
        });
    }

    public void GetUserData(string userId, Action<DataBaseUserData> onResponse)
    {
        string userDocumentPath = string.Join(',', "users", userId);
        DatabaseReadRequestData databaseReadRequestData = new DatabaseReadRequestData(userDocumentPath);

        _dataBaseService.GetDocument<FirestoreUserData>(databaseReadRequestData, (userDataResponse) =>
        {
            if (userDataResponse != null && userDataResponse.data != null)
            {
                FirestoreUserData firestoreUserData = userDataResponse.data;

                Debug.Log($"User Data Retrieved: {JsonUtility.ToJson(firestoreUserData)}");

                DataBaseUserData dataBaseUserData = ConvertFirestoreUserDataToDataBaseUserData(firestoreUserData);

                onResponse?.Invoke(dataBaseUserData);
            }
            else
            {
                Debug.LogWarning("User data not found.");
                onResponse?.Invoke(null);
            }
        });
    }

    private DataBaseUserData ConvertFirestoreUserDataToDataBaseUserData(FirestoreUserData firestoreUserData)
    {
        if (firestoreUserData == null)
        {
            return null;
        }

        firestoreUserData.UserSettingsData.userAudioSettingsData.UserMasterVolume =
            firestoreUserData.UserSettingsData.userAudioSettingsData.userMasterVolume;
        firestoreUserData.UserSettingsData.userAudioSettingsData.UsersfxVolume =
            firestoreUserData.UserSettingsData.userAudioSettingsData.usersfxVolume;
        firestoreUserData.UserSettingsData.userAudioSettingsData.UserMusicVolume =
            firestoreUserData.UserSettingsData.userAudioSettingsData.userMusicVolume;

        firestoreUserData.UserSettingsData.userAudioSettingsData.UserMasterVolumeMute =
            firestoreUserData.UserSettingsData.userAudioSettingsData.userMasterVolumeMute;
        firestoreUserData.UserSettingsData.userAudioSettingsData.UsersfxVolumeMute =
            firestoreUserData.UserSettingsData.userAudioSettingsData.usersfxVolumeMute;
        firestoreUserData.UserSettingsData.userAudioSettingsData.UserMusicVolumeMute =
            firestoreUserData.UserSettingsData.userAudioSettingsData.userMusicVolumeMute;

        return new DataBaseUserData(firestoreUserData.Id, firestoreUserData.Coins_count, firestoreUserData.UserSettingsData);
    }
}
