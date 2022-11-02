using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    public static int InteractableLayer => LayerMask.NameToLayer("Interactable");

    public BoxCollider2D BoxCollider { get; private set; }

    public void Awake()
    {
        gameObject.layer = InteractableLayer;
        BoxCollider = GetComponent<BoxCollider2D>();
    }
}