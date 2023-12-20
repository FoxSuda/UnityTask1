using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseService : IDataBaseService
{
    public void CreateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        throw new NotImplementedException();
    }

    public void DeleteDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        throw new NotImplementedException();
    }

    public void GetDocument<T>(DatabaseReadRequestData readRequestData, Action<DatabaseResponseData<T>> onResponse)
    {
        throw new NotImplementedException();
    }

    public void UpdateDocument<T, D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse)
    {
        throw new NotImplementedException();
    }
}
