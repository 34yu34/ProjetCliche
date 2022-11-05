using Interactables;
using Items;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(ItemHolder))]
[RequireComponent(typeof(Interactable))]
public class Workbench: MonoBehaviour
{
    private ItemHolder _holder;
    private Interactable _interactable;

    private void Awake()
    {
        _holder = GetComponent<ItemHolder>();
        _interactable = GetComponent<Interactable>();
    }
}