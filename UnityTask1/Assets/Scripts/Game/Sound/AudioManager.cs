using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float mainVolume = 1.0f;
    private float sfxVolume = 1.0f;
    private float musicVolume = 1.0f;

    public float MainVolume { get => mainVolume; set => mainVolume = value; }
    public float SfxVolume { get => sfxVolume; set => sfxVolume = value; }
    public float MusicVolume { get => musicVolume; set => musicVolume = value; }
}
