using System;
using NaughtyAttributes;
using UnityEngine;

namespace Grids
{
    public class GridObject : MonoBehaviour
    {

        [Button]
        private void PlaceOnGrid()
        {
            GridService.Instance.MainGrid.PlaceOnNearestGrid(gameObject);
        }
    }
}