using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSlider : MonoBehaviour
{

    private Slider volume_slider;

    private void Start()
    {
        volume_slider = GetComponentInChildren<Slider>();
        
        if(volume_slider == null)
        {
            Debug.LogError("master volume slider script wasn't attached to a slider.");
            return;
        }

        volume_slider.onValueChanged.AddListener(val => AudioListener.volume = val);
        AudioListener.volume = volume_slider.value;
    }

}
