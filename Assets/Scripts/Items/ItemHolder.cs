using UnityEngine;

namespace Items
{
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private Item _heldItem;
        public Item HeldItem => _heldItem;

        public bool IsHolding => _heldItem.IsNull();

        public bool CanTransferTo(ItemHolder holder)
        {
            return !holder.IsHolding && IsHolding;
        }

        public bool TransferTo(ItemHolder holder)
        {
            holder._heldItem = _heldItem;
            _heldItem = Item.NullItem;

            return true;
        }
    }
}