using System;
using NaughtyAttributes;
using UnityEngine;

namespace Grids
{
    public class GridObject : MonoBehaviour
    {
        private Grid _currentGrid = null;

        public Grid CurrentGrid
        {
            get => _currentGrid ??= GridService.Instance.MainGrid;
            set => _currentGrid = value;
        } 

        [Button]
        private void PlaceOnGrid()
        {
            CurrentGrid.PlaceOnNearestGrid(gameObject);
        }
    }
}