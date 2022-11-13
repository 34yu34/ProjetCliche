using Grids;
using Items;
using Players;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(ItemHolder))]
    [RequireComponent(typeof(GridObject))]
    public class Workbench: Interactable
    {
        private ItemHolder _holder;

        private void Awake()
        {
            base.Awake();
            _holder = GetComponent<ItemHolder>();
        }


        public override void ActivityInteract(Player playerThatActivated)
        {
            base.ActivityInteract(playerThatActivated);
            
            
        }

        public override void ItemInteract(Player playerThatActivated)
        {
            base.ItemInteract(playerThatActivated);

            playerThatActivated.ItemHolder.TransferTo(_holder);
        }
    }
}