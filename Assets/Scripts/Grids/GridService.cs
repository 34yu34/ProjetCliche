using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Grids
{
    [ExecuteAlways]
    public class GridService : MonoBehaviour
    {
        private static GridService _instance;

        public static GridService Instance
        {
            get
            {
                if (_instance is not null) return _instance;
            
                _instance = FindObjectOfType<GridService>();
                
                Debug.Assert(_instance is not null, "Must have a GridService in scene to use");

                return _instance;
            }
        }
        
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
                MainGrid.DrawGrid(Vector2Int.zero, _debugMainGridSize, Color.white);
            }
#endif
        }
    }
}