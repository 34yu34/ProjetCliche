using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Helpers
{
    public class Service<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    FindInstance();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            FindInstance();
        }

        private static void FindInstance()
        {
            _instance = FindObjectOfType<T>();

            Debug.Assert(_instance is not null, $"Missing service of type {typeof(T)} in scene");
        }
    }
}