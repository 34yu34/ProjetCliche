using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;

namespace Grids
{
    public class GridObject : MonoBehaviour
    {
        private Grid _currentGrid = null;
        
        [SerializeField]
        [HideInInspector]
        private SpriteRenderer _renderer;

        public Grid CurrentGrid
        {
            get => _currentGrid ??= GridService.Instance.MainGrid;
            set => _currentGrid = value;
        }
        
        private void OnValidate()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        
        [Button]
        private void PlaceOnGrid()
        {
            CurrentGrid.PlaceOnNearestGrid(gameObject);
        }

        [Button]
        private void FitToGrid()
        {
            if (_renderer is null)
            {
                OnValidate();
            }

            var currTransform = _renderer.transform;
            var parent = currTransform.parent;
            
            currTransform.parent = null;
            
            var sprite = _renderer.sprite;
            
            transform.localScale = new Vector3(
                CurrentGrid.Size.x * sprite.pixelsPerUnit / sprite.rect.width,
                CurrentGrid.Size.y * sprite.pixelsPerUnit / sprite.rect.height,
                1.0f
            );

            currTransform.parent = parent;
        }


    }
}