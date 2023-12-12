public interface IRestApiService
{
    void Get(string url);
    void Post<T>(string url, T data);
    void Put<T>(string url, T data);
    void Delete(string url);
}
