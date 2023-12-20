public class DatabaseWriteRequestData<T>
{
    public string Path { get; }
    public T Data { get; }

    public DatabaseWriteRequestData(string path, T data)
    {
        Path = path;
        Data = data;
    }
}