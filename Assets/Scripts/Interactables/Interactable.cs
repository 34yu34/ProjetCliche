using Helpers;
using Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactables
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Interactable : MonoBehaviour
    {
        public static string InteractableLayerName => "Interactable";

        public BoxCollider2D BoxCollider { get; private set; }

        [FormerlySerializedAs("_activeTimer")] [SerializeField] private Timer _activityDurationTimer;
        
        public bool IsActive => _activityDurationTimer.IsRunning;
    
        protected virtual void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer(InteractableLayerName);
            BoxCollider = GetComponent<BoxCollider2D>();
        }

        public virtual void ActivityInteract(Player playerThatActivated)
        {
            if (_activityDurationTimer.IsRunning) return;
        
            _activityDurationTimer.Start();
        }

        public virtual void ItemInteract(Player playerThatActivated)
        {
            
        }
        
    }
}