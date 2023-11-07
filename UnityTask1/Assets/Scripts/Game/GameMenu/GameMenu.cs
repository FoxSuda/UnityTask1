using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private AudioManager audioManager;
    private InputController inputController;
    [SerializeField] private GameObject soundObject;

    [SerializeField] private GameObject inputControllerObject;
    [SerializeField] private GameObject ObjectMainMenu;
    [SerializeField] private GameObject ObjectOptionsMenu;
    [SerializeField] private Button[] buttonObjectsMenu = new Button[3];

    public bool mainVolumeMute = false;
    public bool sfxVolumeMute = false;
    public bool musicVolumeMute = false;

    private bool menuOpened = false;

    private void Start()
    {
        inputController = inputControllerObject.GetComponent<InputController>();
        inputController.OnOpenCloseGameMenu += GamePaused;
        inputController.OnOpenCloseGameMenu += MainMenu;
    }

    private void Awake()
    {
        buttonObjectsMenu[0].onClick.AddListener(GamePaused);
        buttonObjectsMenu[0].onClick.AddListener(MainMenu);
        buttonObjectsMenu[1].onClick.AddListener(OptionsMenu);
        buttonObjectsMenu[2].onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        buttonObjectsMenu[0].onClick.RemoveListener(GamePaused);
        buttonObjectsMenu[0].onClick.RemoveListener(MainMenu);
        buttonObjectsMenu[1].onClick.RemoveListener(OptionsMenu);
        buttonObjectsMenu[2].onClick.RemoveListener(QuitGame);
    }

    private void GamePaused()
    {
        if (Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    private void MainMenu()
    {
        if (!menuOpened)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ObjectMainMenu.SetActive(true);
            menuOpened = true;
        } else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ObjectMainMenu.SetActive(false);
            ObjectOptionsMenu.SetActive(false);
            menuOpened = false;
        }
    }
    
    private void OptionsMenu()
    {
        ObjectMainMenu.SetActive(false);
        ObjectOptionsMenu.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    
    private void MuteMainVolume()
    {
        mainVolumeMute = !mainVolumeMute;
    }
    
    private void MuteSFXVolume()
    {
        sfxVolumeMute = !sfxVolumeMute;
    }
    
    private void MuteMusicVolume()
    {
        musicVolumeMute = !musicVolumeMute;
    }

    private void OnMainVolumeChanged(float newValue)
    {
        audioManager.MainVolume = newValue;
    }
    
    private void OnSFXVolumeChanged(float newValue)
    {
        audioManager.SfxVolume = newValue;
    }
    
    private void OnMusicVolumeChanged(float newValue)
    {
        audioManager.MusicVolume = newValue;
    }
}
