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

    public async void CreateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        try
        {
            string collection = writeRequestData.Path.Split(',')[0];
            string document = writeRequestData.Path.Split(',')[1];

            DocumentReference docRef = _firestoreDatabase.Collection(collection).Document(document);

            Task setAsynTask = docRef.SetAsync(writeRequestData.Data);
            await setAsynTask;

            Debug.Log(setAsynTask.Status.ToString());
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void DeleteDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        throw new NotImplementedException();
    }

    public async void GetDocument<T>(DatabaseReadRequestData readRequestData, Action<DatabaseResponseData<T>> onResponse)
    {
        try
        {
            string collection = readRequestData.path.Split(',')[0];
            string document = readRequestData.path.Split(',')[1];

            DocumentReference docRef = _firestoreDatabase.Collection(collection).Document(document);
            DocumentSnapshot documentSnapShot = await docRef.GetSnapshotAsync();

            T firestoreData = documentSnapShot.ConvertTo<T>();

            DatabaseResponseData<T> databaseResponseData = new DatabaseResponseData<T>();
            databaseResponseData.data = firestoreData;

            onResponse?.Invoke(databaseResponseData);
            Debug.Log(documentSnapShot.Reference.Id);

        } catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public async void UpdateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
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