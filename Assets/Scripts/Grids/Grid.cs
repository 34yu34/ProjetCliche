using System;
using Helpers;
using UnityEngine;

namespace Grids
{
    [Serializable]
    public class Grid
    {
        [SerializeField] 
        private Vector2 _origin = Vector2.zero;
        
        [SerializeField] 
        private Vector2 _size = Vector2.one;
        
        public Vector2Int WorldToGrid(Vector2 worldPos)
        {
            var floatGrid = (worldPos / _size) - _origin;

            return floatGrid.Round();
        }

        public Vector2 GridToWorld(Vector2Int gridPos)
        {
            return (gridPos + _origin) * _size;
        }

        public void PlaceOnNearestGrid(GameObject obj)
        {
            var pos = GridToWorld(WorldToGrid(obj.transform.position));

            obj.transform.position = pos;
        }

        public void DrawGrid(Vector2Int centerCoord, Vector2Int size)
        {
#if UNITY_EDITOR
            for (int i = centerCoord.x - size.x; i < centerCoord.x + size.x; i++)
            {
                for (int j = centerCoord.y - size.y; j < centerCoord.y + size.y; j++)
                {
                    CustomDebug.DrawBox(new Vector4(i, j, 0f, 0f), _size, Color.white);
                }
            }
#endif
        }
    }
}