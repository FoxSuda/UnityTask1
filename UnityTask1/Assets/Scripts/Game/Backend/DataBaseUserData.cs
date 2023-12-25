public class DataBaseUserData
{
    public string Id { get; }
    public int Coins_count { get; set; }
    public UserSettingsData UserSettingsData { get; }

    public DataBaseUserData(string id, int coins_count, UserSettingsData userSettingsData)
    {
        Id = id;
        Coins_count = coins_count;
        UserSettingsData = userSettingsData;
    }
}