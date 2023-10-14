using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootSceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
