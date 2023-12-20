using System;

public interface IGameBackendService
{
    public void Initialize();
    public void Initialize(IAuthService authService, IDataBaseService dataBaseService);
    public void CreateUser(DataBaseUserData dataBaseUserData);
    public void GetUserData(string userId, Action<DataBaseUserData> onResponse);
}
