﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items
{
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private Item _heldItem;
        public Item HeldItem => _heldItem;

        [SerializeField] private SpriteRenderer _itemSprite;
        
        public bool IsHolding => !_heldItem.IsNull();

        private void Awake()
        {
            _heldItem ??= Item.NullItem;
        }

        public bool CanTransferTo(ItemHolder holder)
        {
            return !holder.IsHolding && IsHolding;
        }

        public void GiveItem(Item item)
        {
            if (IsHolding) return;

            SetItem(item);
        }

        public bool TransferTo(ItemHolder holder)
        {
            if (!CanTransferTo(holder)) return false;
            
            holder.SetItem(_heldItem);
            _heldItem = Item.NullItem;

            return true;
        }

        private void SetItem(Item item)
        {
            if (IsHolding)
            {
                return;
            }

            _heldItem = item;

            SetupSprite();
        }

        private void SetupSprite()
        {
            if (_itemSprite == null) return;
            
            _itemSprite.sprite = _heldItem.UIImage;
        }
    }
}