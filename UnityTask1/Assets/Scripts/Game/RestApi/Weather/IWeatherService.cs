using System;

public interface IWeatherService
{
    public void initialize(IRestApiService restApiService);
    public void GetWeather(float lat, float lon, Action<WeatherData> onDataReceived);
}
