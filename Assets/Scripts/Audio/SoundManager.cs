using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource effect_source;
    [SerializeField]
    private AudioSource music_source;
    [SerializeField]
    private Slider volume_slider;

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

    private void Start()
    {
        volume_slider.onValueChanged.AddListener(val => AudioListener.volume = val);
        AudioListener.volume = volume_slider.value;
    }

    public void PlaySound(AudioClip sound)
    {
        effect_source.PlayOneShot(sound);
    }
}
