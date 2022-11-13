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

        protected override void Awake()
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

            if (!playerThatActivated.ItemHolder.IsHolding && _holder.IsHolding)
            {
                _holder.TransferTo(playerThatActivated.ItemHolder);
                return;
            }

            if (playerThatActivated.ItemHolder.IsHolding && !_holder.IsHolding)
            {
                playerThatActivated.ItemHolder.TransferTo(_holder);
            }
        }
    }
}