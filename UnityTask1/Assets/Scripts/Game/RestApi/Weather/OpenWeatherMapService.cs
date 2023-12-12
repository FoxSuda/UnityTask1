using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IWeatherService
{
    private string apiKey = "d9edbb1b6ff1e03612e4b673539b8cbb";
    private string weatherUrl = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
    private IRestApiService _restApiService;

    public void initialize(IRestApiService restApiService)
    {
        _restApiService = restApiService;
    }

    public void GetWeather(float lat, float lon)
    {
        string url = string.Format(weatherUrl, lat, lon, apiKey);
        _restApiService.Get(url);
    }
}
