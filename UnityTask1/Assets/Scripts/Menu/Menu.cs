using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Task1.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(StartGame);
            quitButton.onClick.RemoveListener(QuitGame);
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Main");
            SceneManager.LoadScene("MainPart0", LoadSceneMode.Additive);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

