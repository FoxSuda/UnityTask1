using System;
using UnityEngine;

public class Weather : MonoBehaviour
{

    [SerializeField] private OpenWeatherMapService openWeatherMapService;
    [SerializeField] private UnityRestApi unityRestApi;

    void Start()
    {
        openWeatherMapService.initialize(unityRestApi);
        openWeatherMapService.GetWeather(-25f, -34f, OnWeatherDataReceived);
    }

    private void OnWeatherDataReceived(WeatherData weatherData)
    {
        Debug.Log("Received weather data: " + weatherData.coord);
    }
}
