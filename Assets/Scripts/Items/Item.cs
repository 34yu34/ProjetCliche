using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 0)]
    public class Item : ScriptableObject
    {
        private static Item _nullItem;

        public static Item NullItem
        {
            get
            {
                if (_nullItem is not null) return _nullItem;
                
                _nullItem = CreateInstance<Item>();
                _nullItem._uiImage = null;

                return _nullItem;
            }
        }
        
        [SerializeField] private Sprite _uiImage;

        public static explicit operator bool(Item item)
        {
            return item.IsNull();
        }

        public bool IsNull() => _nullItem == this;
    }
}