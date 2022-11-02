using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public static int InteractableLayer => LayerMask.NameToLayer("Interactable");

    public BoxCollider2D BoxCollider { get; private set; }

    [SerializeField] private Timer ActiveTimer;

    public bool IsActive => ActiveTimer.IsRunning;
    
    protected virtual void Awake()
    {
        gameObject.layer = InteractableLayer;
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    public virtual void Interact()
    {
        if (ActiveTimer.IsRunning)
        {
            return;
        }
        
        ActiveTimer.Start();
    }
}