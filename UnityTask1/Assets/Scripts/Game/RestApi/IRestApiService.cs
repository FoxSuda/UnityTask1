using System;

public interface IRestApiService
{
    void Get<T>(string url, Action<T> onDataReceived);
    void Post<T>(string url, T data);
    void Put<T>(string url, T data);
    void Delete(string url);
}
