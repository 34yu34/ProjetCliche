using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsVolumeSlider : MonoBehaviour
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

        volume_slider.onValueChanged.AddListener(val => SoundManager.Instance.SetEffectsVolume(val));
        SoundManager.Instance.SetEffectsVolume(volume_slider.value);
    }

}
