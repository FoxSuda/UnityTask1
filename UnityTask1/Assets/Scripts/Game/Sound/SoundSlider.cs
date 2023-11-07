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

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void Start()
    {
        audioMixer.GetFloat(volumeChannel, out float startVolume);
        volumeSlider.value = (startVolume - minVolume) / (maxVolume - minVolume);
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
