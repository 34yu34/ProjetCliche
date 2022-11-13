using System;
using Grids;
using Items;
using Players;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(ItemHolder))]
    [RequireComponent(typeof(GridObject))]
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

        private void OnEnable()
        {
            _interactable.ItemInteractEvent.AddListener(ItemInteract);
        }

        private void OnDisable()
        {
            _interactable.ItemInteractEvent.RemoveListener(ItemInteract);
        }

        private void ItemInteract(Player playerThatActivated)
        {
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