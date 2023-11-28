using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private SceneUnloader sceneUnloader;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        sceneUnloader = GetComponent<SceneUnloader>();
    }

    public void LoadScene(string scene)
    {
        sceneLoader.LoadScene(scene);
    }

    public void UnloadScene(string scene)
    {
        sceneUnloader.UnloadScene(scene);
    }
}
