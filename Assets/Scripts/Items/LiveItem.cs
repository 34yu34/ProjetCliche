using System;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LiveItem : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        [SerializeField] private Item _currentItem;

        public Item CurrentItem
        {
            get => _currentItem;

            set => InitializeNewItem(value);
        }
        
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (!CurrentItem.IsNull())
            {
                InitializeNewItem(CurrentItem);
            }
        }
        
        private void InitializeNewItem(Item newItem)
        {
            _currentItem = newItem;
            _renderer.sprite = _currentItem.UIImage;
        }
    }
}