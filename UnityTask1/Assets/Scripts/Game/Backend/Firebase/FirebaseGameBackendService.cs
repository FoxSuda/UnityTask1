using System;
using System.Collections;
using System.Collections.Generic;
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
        firestoreUserData.Id = dataBaseUserData.Id;
        firestoreUserData.Coins_count = dataBaseUserData.Coins_count;
        firestoreUserData.UserSettingsData = dataBaseUserData.UserSettingsData;

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
        throw new NotImplementedException();
    }
}
