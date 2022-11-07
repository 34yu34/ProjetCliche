using System;
using Helpers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Grids
{
    [ExecuteAlways]
    public class GridService : Service<GridService>
    {
        [SerializeField] private Grid _mainGrid;
        public Grid MainGrid => _mainGrid;

        [SerializeField] private bool _debugMainGrid;
        [SerializeField] private Vector2Int _debugMainGridSize;

        public void Update()
        {
            DrawMainDebugGrid();
        }

        private void DrawMainDebugGrid()
        {
#if UNITY_EDITOR
            if (_debugMainGrid)
            {
                MainGrid.DrawGrid(MainGrid.Origin.Round(), _debugMainGridSize, Color.white);
            }
#endif
        }
    }
}