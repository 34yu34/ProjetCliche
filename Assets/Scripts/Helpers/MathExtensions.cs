using UnityEngine;

namespace Helpers
{
    public static class MathExtensions
    {
        /// <summary>
        /// Rounds Vector2 to Vector2Int.
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector2Int Round(this Vector2 vector2)
        {
            return new Vector2Int(
                (int)Mathf.Round(vector2.x),
                (int)Mathf.Round(vector2.y)
            );
        }
    }
}