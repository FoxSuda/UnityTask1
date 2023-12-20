using System.Collections;
using UniStorm;
using Unity.VisualScripting;
using UnityEngine;

public class Weather : MonoBehaviour
{
    private const int TIME_WEATHER_CHANGED = 120;

    [SerializeField] private OpenWeatherMapService openWeatherMapService;
    [SerializeField] private UnityRestApi unityRestApi;
    [SerializeField] private UniStormSystem stormSystem;

    private float minNumberFloat = 0.0f;
    private float maxNumberFloat = 50.0f;

    private int minNumberInt = 0;
    private int maxNumberInt = 5;

    void Start()
    {
        openWeatherMapService.initialize(unityRestApi);
        StartCoroutine(WeatherChanged());
    }

    private IEnumerator WeatherChanged()
    {
        while (true)
        {
            openWeatherMapService.GetWeather(GetRandomNumberFloat(), GetRandomNumberFloat(), OnWeatherDataReceived);
            yield return new WaitForSeconds(TIME_WEATHER_CHANGED);
        }
    }

    private void OnWeatherDataReceived(WeatherData weatherData)
    {
        Debug.Log("Received weather data: " + weatherData.weather[0].main);

        if (weatherData.weather[0].main == "Clear")
        {
            UniStormManager.Instance.ChangeWeatherWithTransition(stormSystem.AllWeatherTypes[Random.Range(0, 1)]);
            Debug.Log("Start weather Clear!!!!");
        } else if (weatherData.weather[0].main == "Clouds")
        {
            UniStormManager.Instance.ChangeWeatherWithTransition(stormSystem.AllWeatherTypes[Random.Range(2, 4)]);
            Debug.Log("Start weather Clouds!!!!");
        } else if (weatherData.weather[0].main == "Rain")
        {
            UniStormManager.Instance.ChangeWeatherWithTransition(stormSystem.AllWeatherTypes[Random.Range(12, 14)]);
            Debug.Log("Start weather Rain!!!!");
        } else if (weatherData.weather[0].main == "Snow")
        {
            UniStormManager.Instance.ChangeWeatherWithTransition(stormSystem.AllWeatherTypes[Random.Range(16, 18)]);
            Debug.Log("Start weather Snow!!!!");
        }
    }

    private float GetRandomNumberFloat()
    {
        return Random.Range(minNumberFloat, maxNumberFloat);
    }
    
    private int GetRandomNumberInt()
    {
        return Random.Range(minNumberInt, maxNumberInt);
    }
}
