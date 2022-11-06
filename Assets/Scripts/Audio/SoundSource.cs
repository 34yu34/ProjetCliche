using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    [SerializeField] 
    private AudioClip clip;

    private SoundManager manager;

    void Start()
    {
        manager = FindObjectOfType<SoundManager>();
        if(manager == null)
        {
            Debug.LogError("there are no soundManagers!");
        }
    }

    public void playSound()
    {
        manager.PlaySound(clip);
    }

}
