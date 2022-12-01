using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items
{
    public class ItemHolder : MonoBehaviour
    {
        private Stack<Item> _heldItems;
        [SerializeField] private int _maxQuantity = 1;

        [SerializeField] private SpriteRenderer _itemSprite;
        
        public bool IsHolding => _heldItems.Count > 0;
        public bool IsFull => _heldItems.Count == _maxQuantity;

        public Item HeldItem => IsHolding ? _heldItems.Peek() : Item.NullItem;

        public Item[] AllItems => _heldItems.ToArray();

        private void Awake()
        {
            _heldItems = new Stack<Item>();
        }

        public bool CanTransferTo(ItemHolder holder)
        {
            return !holder.IsFull && IsHolding;
        }

        public bool TransferTo(ItemHolder holder)
        {
            if (!CanTransferTo(holder)) return false;
            
            holder.GiveItem(PopItem());

            return true;
        }
        
        public void GiveItem(Item item)
        {
            if (IsFull) return;
            
            _heldItems.Push(item);

            SetupSprite(item);
        }

        public void RemoveAll()
        {
            for (var i = 0; i < _heldItems.Count; i++)
            {
                PopItem();
            }
        }

        public Item PopItem()
        {
            if (!IsHolding) return Item.NullItem;

            var removedItem = _heldItems.Pop();
            
            RemoveSprite();

            return removedItem;
        }

        private void SetupSprite(Item item)
        {
            if (_itemSprite == null) return;
            
            _itemSprite.sprite = item.UIImage;
        }

        private void RemoveSprite()
        {
            if (_itemSprite == null) return;

            _itemSprite.sprite = null;
        }
    }
}