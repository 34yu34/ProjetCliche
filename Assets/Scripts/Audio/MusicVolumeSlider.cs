using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{

    private Slider volume_slider;

    private void Start()
    {
        volume_slider = GetComponentInChildren<Slider>();
        
        if(volume_slider == null)
        {
            Debug.LogError("Effects volume slider script wasn't attached to a slider.");
            return;
        }

        volume_slider.onValueChanged.AddListener(val => SoundManager.Instance.SetMusicVolume(val));
        SoundManager.Instance.SetMusicVolume(volume_slider.value);
    }

}
