using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource effect_source;
    [SerializeField]
    private AudioSource music_source;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetEffectsVolume(float scale)
    {
        if (scale < 0 || scale > 1)
        {
            Debug.LogError("volume scale should always be between 0 and 1 inclusively");
            return;
        }
        effect_source.volume = scale;
    }

    public void SetMusicVolume(float scale)
    {
        if (scale < 0 || scale > 1)
        {
            Debug.LogError("volume scale should always be between 0 and 1 inclusively");
            return;
        }
        music_source.volume = scale;
    }

    public void PlaySound(AudioClip sound, float volumeScale = 1f)
    {
        effect_source.PlayOneShot(sound,volumeScale);
    }
}
