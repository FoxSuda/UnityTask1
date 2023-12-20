using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UnityRestApi : MonoBehaviour, IRestApiService
{
    public void Get<T>(string url, Action<T> onDataReceived)
    {
        StartCoroutine(SendRequest(url, HttpMethod.Get, onDataReceived: onDataReceived));
    }

    public void Post<T>(string url, T data)
    {
        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(SendRequest<UnityRestApi>(url, HttpMethod.Post, jsonData));
    }

    public void Put<T>(string url, T data)
    {
        string jsonData = JsonUtility.ToJson(data);
        StartCoroutine(SendRequest<UnityRestApi>(url, HttpMethod.Put, jsonData));
    }

    public void Delete(string url)
    {
        StartCoroutine(SendRequest<UnityRestApi>(url, HttpMethod.Delete));
    }

    private IEnumerator SendRequest<T>(string url, HttpMethod method, string jsonData = null, Action<T> onDataReceived = null)
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
            jsonData = request.downloadHandler.text;
            Debug.Log("Response: " + request.downloadHandler.text);
            if (method == HttpMethod.Get)
            {
                T data = JsonUtility.FromJson<T>(jsonData);
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
