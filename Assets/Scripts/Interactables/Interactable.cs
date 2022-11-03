using Helpers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactables
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Interactable : MonoBehaviour
    {
        public static string InteractableLayerName => "Interactable";

        public BoxCollider2D BoxCollider { get; private set; }

        [SerializeField] private Timer _activeTimer;

        public bool IsActive => _activeTimer.IsRunning;
    
        protected virtual void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer(InteractableLayerName);
            BoxCollider = GetComponent<BoxCollider2D>();
        }

        public virtual void Interact()
        {
            if (_activeTimer.IsRunning) return;
        
            _activeTimer.Start();
        }
    }
}