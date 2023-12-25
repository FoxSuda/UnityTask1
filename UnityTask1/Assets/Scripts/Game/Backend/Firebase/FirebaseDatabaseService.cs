using Firebase.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseDatabaseService : IDataBaseService
{
    private FirebaseFirestore _firestoreDatabase;

    public FirebaseDatabaseService()
    {
        _firestoreDatabase = FirebaseFirestore.DefaultInstance;
    }

    public void CreateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        Task createDocumentImp = CreateDocumentImp(writeRequestData, onResponse);
    }

    public void DeleteDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        throw new NotImplementedException();
    }

    public void GetDocument<T>(DatabaseReadRequestData readRequestData, Action<DatabaseResponseData<T>> onResponse)
    {
        Task getDocumentImp = GetDocumentImp(readRequestData, onResponse);
    }

    public void UpdateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        Task updateDocumentImp = UpdateDocumentImp(writeRequestData, onResponse);
    }

    private async Task CreateDocumentImp<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        try
        {
            string collection = writeRequestData.Path.Split(',')[0];
            string document = writeRequestData.Path.Split(',')[1];

            DocumentReference docRef = _firestoreDatabase.Collection(collection).Document(document);

            Debug.Log("Data to be sent to Firestore: " + JsonUtility.ToJson(writeRequestData.Data));

            Task setAsynTask = docRef.SetAsync(writeRequestData.Data);
            await setAsynTask;

            Debug.Log(setAsynTask.Status.ToString());
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private async Task GetDocumentImp<T>(DatabaseReadRequestData readRequestData, Action<DatabaseResponseData<T>> onResponse)
    {
        try
        {
            string collection = readRequestData.Path.Split(',')[0];
            string document = readRequestData.Path.Split(',')[1];

            DocumentReference docRef = _firestoreDatabase.Collection(collection).Document(document);
            DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

            T firestoreData = documentSnapShot.ConvertTo<T>();

            DatabaseResponseData<T> databaseResponseData = new DatabaseResponseData<T>();
            databaseResponseData.data = firestoreData;

            onResponse?.Invoke(databaseResponseData);
            Debug.Log(documentSnapShot.Reference.Id);

        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private async Task UpdateDocumentImp<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        try
        {
            string collection = writeRequestData.Path.Split(',')[0];
            string document = writeRequestData.Path.Split(',')[1];

            DocumentReference docRef = _firestoreDatabase.Collection(collection).Document(document);

            var dataDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(writeRequestData.Data));

            Task updateAsyncTask = docRef.UpdateAsync(dataDictionary);
            await updateAsyncTask;

            Debug.Log(updateAsyncTask.Status.ToString());
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}