using UnityEngine;

public class Sound : MonoBehaviour
{

    private AudioManager audioManager;
    private GameMenu soundMuteUnmute;
    [SerializeField] private GameObject gameMenuObject;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = new AudioSource();
        audioManager = GetComponent<AudioManager>();
        soundMuteUnmute = gameMenuObject.GetComponent<GameMenu>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound, int soundCategory, float volume = 0.2f, bool destroyed = false)
    {
        if (soundCategory == (int)SoundCategory.SFX)
        {
            if (!soundMuteUnmute.mainVolumeMute && !soundMuteUnmute.sfxVolumeMute)
            {
                volume = volume * audioManager.SfxVolume * audioManager.MainVolume;
            } else
            {
                volume = 0f;
            }
        }
        else if (soundCategory == (int)SoundCategory.Music)
        {
            if (!soundMuteUnmute.mainVolumeMute && !soundMuteUnmute.musicVolumeMute)
            {
                volume = volume * audioManager.MusicVolume * audioManager.MainVolume;
            } else
            {
                volume = 0f;
            }
        }

        if (destroyed)
            AudioSource.PlayClipAtPoint(sound, transform.position, volume);
        else
            audioSource.PlayOneShot(sound, volume);
    }

    public enum SoundCategory
    {
        SFX,
        Music
    }

}
