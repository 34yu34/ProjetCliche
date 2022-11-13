using Interactables;
using Players;
using UnityEngine;

namespace Items
{
    public class ItemDispenser : Interactable
    {
        [SerializeField] private Item _itemToGive;


        public override void ActivityInteract(Player player)
        {
            base.ActivityInteract(player);
            
        }

        public override void ItemInteract(Player player)
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