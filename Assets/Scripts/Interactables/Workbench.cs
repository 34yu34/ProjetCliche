using Grids;
using Items;
using NaughtyAttributes;
using Players;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(ItemHolder))]
    [RequireComponent(typeof(GridObject))]
    [RequireComponent(typeof(Interactable))]
    public class Workbench: MonoBehaviour
    {
        private ItemHolder _holder;
        private Interactable _interactable;
        [SerializeField] private WorkbenchData _workbenchData;

        [ShowNonSerializedField] private Recipe _currentRecipe;
        [ShowNonSerializedField] private float _currentRecipeCompletion;
        
        private void Awake()
        {
            _currentRecipe = Recipe.NullRecipe;
            _holder = GetComponent<ItemHolder>();
            _interactable = GetComponent<Interactable>();
            
            Debug.Assert(_workbenchData is not null, "A workbench is in the scene without any data attached to it");
        }

        private void OnEnable()
        {
            _interactable.ItemInteractEvent.AddListener(ItemInteract);
        }

        private void OnDisable()
        {
            _interactable.ItemInteractEvent.RemoveListener(ItemInteract);
        }

        private void FixedUpdate()
        {
            
        }

        private void ActivityInteract(Player playerThatActivated)
        {
            
        }

        private void ItemInteract(Player playerThatActivated)
        {
            if (!playerThatActivated.ItemHolder.IsHolding && _holder.IsHolding)
            {
                _holder.TransferTo(playerThatActivated.ItemHolder);
                return;
            }

            if (playerThatActivated.ItemHolder.IsHolding && !_holder.IsHolding)
            {
                playerThatActivated.ItemHolder.TransferTo(_holder);
            }
        }
    }
}