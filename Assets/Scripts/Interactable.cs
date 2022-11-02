using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public static int InteractableLayer => LayerMask.NameToLayer("Interactable");


    public void Start()
    {
        gameObject.layer = InteractableLayer;
    }
}