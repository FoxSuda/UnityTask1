using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task1.Initialization
{
    public class BootSceneController : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}

