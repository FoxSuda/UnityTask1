using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string audioChannel;
    [SerializeField] private float minVolume;
    [SerializeField] private float maxVolume;
    private bool isMuted;
    [SerializeField] private Slider volumeSlider;
    private Text text;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(delegate { Unmute(); });
        text = GetComponentInChildren<Text>();
    }

    public void ChangeAudioState()
    {
        if (isMuted == true)
        {
            Unmute();
            return;
        }
        isMuted = true;
        Mute();
    }

    private void Mute()
    {
        isMuted = true;
        mixer.SetFloat(audioChannel, minVolume);
        text.color = Color.magenta;
    }

    private void Unmute()
    {
        isMuted = false;
        mixer.SetFloat(audioChannel, minVolume + (maxVolume - minVolume) * volumeSlider.value);
        text.color = Color.black;
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveAllListeners();
    }
}
