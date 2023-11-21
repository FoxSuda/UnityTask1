namespace Task1.FilesManagment
{
    public interface IFileUploader<T>
    {
        public void UploadFile(string path, T File);
    }
}
