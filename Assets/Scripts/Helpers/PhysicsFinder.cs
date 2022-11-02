using UnityEngine;

namespace Helpers
{
    public static class PhysicsFinder
    {
        public static T RaycastFind<T>(Vector2 position, Vector2 direction, float distance = float.MaxValue, int layer = ~0, bool debug = true) where T: class
        {
            var hit = Physics2D.Raycast(position, 
                direction, 
                distance,
                layer
            );

            if (debug)
            {
                CustomDebug.DrawLine(position, direction, distance, Color.red);
            }

            return !hit ? null : hit.collider.GetComponent<T>();
        }
    }
}