using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float minVolume;
    [SerializeField] private float maxVolume;
    [SerializeField] private string volumeChannel;
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private GameObject soundOptions;
    private SoundSettings soundSettings;

    private void Awake()
    {
       volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void Start()
    {
        audioMixer.SetFloat(volumeChannel, minVolume + (maxVolume - minVolume) * volumeSlider.value);
        if (soundOptions != null)
        {
            soundOptions.SetActive(false);
        }
    }

    public void ChangeVolume()
    {
        audioMixer.SetFloat(volumeChannel, minVolume + (maxVolume - minVolume) * volumeSlider.value);
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveAllListeners();
    }
}
