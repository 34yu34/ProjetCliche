using System;
using Interactables;
using Players;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Interactable))]
    public class ItemDispenser : MonoBehaviour
    {
        [SerializeField] private Item _itemToGive;

        private Interactable _interactable;

        private void Awake()
        {
            _interactable = GetComponent<Interactable>();
        }

        private void OnEnable()
        {
            _interactable.ItemInteractEvent.AddListener(ItemInteract);
        }

        private void OnDisable()
        {
            _interactable.ItemInteractEvent.RemoveListener(ItemInteract);
        }

        public void ItemInteract(Player player)
        {
            if (player.ItemHolder.HeldItem == _itemToGive)
            {
                player.ItemHolder.RemoveItem();
                return;
            }
            
            player.ItemHolder.GiveItem(_itemToGive);
        }
    }
}