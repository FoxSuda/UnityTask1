using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UnityRestApi : MonoBehaviour, IRestApiService
{
    UnityWebRequest request;

    public void Get(string url, Action<WeatherData> onDataReceived)
    {
        string jsonData = null;
        StartCoroutine(SendRequest(url, HttpMethod.Get, jsonData, onDataReceived));
    }

    public void Post<T>(string url, T data)
    {
        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(SendRequest(url, HttpMethod.Post, jsonData));
    }

    public void Put<T>(string url, T data)
    {
        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(SendRequest(url, HttpMethod.Put, jsonData));
    }

    public void Delete(string url)
    {
        StartCoroutine(SendRequest(url, HttpMethod.Delete));
    }

    private IEnumerator SendRequest(string url, HttpMethod method, string jsonData = null, Action<WeatherData> onDataReceived = null)
    {

        UnityWebRequest request;

        switch (method)
        {
            case HttpMethod.Get:
                request = UnityWebRequest.Get(url);
                break;
            case HttpMethod.Post:
                request = UnityWebRequest.PostWwwForm(url, jsonData);
                break;
            case HttpMethod.Put:
                request = UnityWebRequest.Put(url, jsonData);
                break;
            case HttpMethod.Delete:
                request = UnityWebRequest.Delete(url);
                break;
            default:
                Debug.LogError("Unsupported HTTP method");
                yield break;
        }

        request.SetRequestHeader("Content-Type", "application/json");

        if (method == HttpMethod.Post || method == HttpMethod.Put)
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            if (method == HttpMethod.Get)
            {
                WeatherData data = JsonUtility.FromJson<WeatherData>(jsonData);
                onDataReceived?.Invoke(data);
            }
        }
    }
}

public enum HttpMethod
{
    Get,
    Post,
    Put,
    Delete
}
