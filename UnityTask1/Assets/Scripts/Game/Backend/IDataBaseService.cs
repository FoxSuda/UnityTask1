using System;

public interface IDataBaseService
{
    public void GetDocument<T>(DatabaseReadRequestData readRequestData, Action<DatabaseResponseData<T>> onResponse);
    public void CreateDocument<T,D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse);
    public void UpdateDocument<T,D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse);
    public void DeleteDocument<T,D>(DatabaseWriteRequestData<T> writeRequestData, Action<DatabaseResponseData<D>> onResponse);
}