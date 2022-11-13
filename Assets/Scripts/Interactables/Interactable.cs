using Helpers;
using Players;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Interactables
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Interactable : MonoBehaviour
    {
        public static string InteractableLayerName => "Interactable";

        public BoxCollider2D BoxCollider { get; private set; }
        
        public UnityEvent<Player> ActivityInteractEvent { get; private set; }
        public UnityEvent<Player> ItemInteractEvent { get; private set; }
        
        public bool IsRunning { get; set; }
        
        protected virtual void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer(InteractableLayerName);
            BoxCollider = GetComponent<BoxCollider2D>();
            ActivityInteractEvent = new UnityEvent<Player>();
            ItemInteractEvent = new UnityEvent<Player>();
        }

        public void ActivityInteract(Player playerThatActivated)
        {
            ActivityInteractEvent.Invoke(playerThatActivated);
        }

        public void ItemInteract(Player playerThatActivated)
        {
            ItemInteractEvent.Invoke(playerThatActivated);
        }
    }
}