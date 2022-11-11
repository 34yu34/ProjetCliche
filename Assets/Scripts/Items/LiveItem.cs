using Grids;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(GridObject))]
    public class LiveItem : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private GridObject _gridController;

        [SerializeField] private Item _currentItem;

        public Item CurrentItem
        {
            get => _currentItem;

            set => InitializeNewItem(value);
        }
        
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _gridController = GetComponent<GridObject>();
            if (!CurrentItem.IsNull())
            {
                InitializeNewItem(CurrentItem);
            }
        }
        
        private void InitializeNewItem(Item newItem)
        {
            _currentItem = newItem;
            _renderer.sprite = _currentItem.UIImage;
            _gridController.FitToGrid();
        }
    }
}