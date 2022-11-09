using System.Dynamic;
using UnityEngine;

namespace Helpers
{
    public class GameObjectManipulator
    {
        public delegate void BasicOperate();
        
        public static void OperateAsRoot(Transform transform, BasicOperate fct)
        {
            var parent = transform.parent;

            transform.parent = null;

            fct();

            transform.parent = parent;
        }
        
    }
}