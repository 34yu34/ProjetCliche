using Interactables;
using Items;
using Players;
using UnityEngine;

namespace Clients
{
    [RequireComponent(typeof(Interactable))]
    public class Client : MonoBehaviour
    {
        [SerializeField] private Item _request;
        
        private Interactable _interactable;
        
        private void Awake()
        {
            _interactable = GetComponent<Interactable>();
            
        }
        private void OnEnable()
        {
            _interactable.ItemInteractEvent.AddListener(ItemInteract);
        }

        private void OnDisable()
        {
            _interactable.ItemInteractEvent.RemoveListener(ItemInteract);
        }

        private void ItemInteract(Player player)
        {
            if (player.ItemHolder.HeldItem == _request)
            {
                player.ItemHolder.PopItem();
            }
        }
    }

}