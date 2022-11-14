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
        private ItemHolder _itemHolder;
        private Interactable _interactable;
        
        [SerializeField]
        [Expandable]
        private WorkbenchData _workbenchData;

        [ShowNonSerializedField] private Recipe _currentRecipe;
        [ShowNonSerializedField] private float _currentRecipeCompletion;
        
        private void Awake()
        {
            _currentRecipe = Recipe.NullRecipe;
            _itemHolder = GetComponent<ItemHolder>();
            _interactable = GetComponent<Interactable>();
            
            Debug.Assert(_workbenchData is not null, "A workbench is in the scene without any data attached to it");
        }

        private void OnEnable()
        {
            _interactable.ItemInteractEvent.AddListener(ItemInteract);
            _interactable.ActivityInteractEvent.AddListener(ActivityInteract);
        }

        private void OnDisable()
        {
            _interactable.ItemInteractEvent.RemoveListener(ItemInteract);
            _interactable.ActivityInteractEvent.RemoveListener(ActivityInteract);
        }

        private void Update()
        {
            _currentRecipeCompletion += Time.deltaTime * _workbenchData._automationCompletionSpeed;

            if (_currentRecipeCompletion >= _currentRecipe.RecipeCompletionTime)
            {
                
            }
        }

        private void ActivityInteract(Player playerThatActivated)
        {
            if (!_currentRecipe.IsNull())
            {
                _currentRecipeCompletion += Time.deltaTime * _workbenchData._playerCompletionSpeed;
            }
        }

        private void ItemInteract(Player playerThatActivated)
        {
            if (_itemHolder.CanTransferTo(playerThatActivated.ItemHolder))
            {
                _itemHolder.TransferTo(playerThatActivated.ItemHolder);
                return;
            }

            if (playerThatActivated.ItemHolder.CanTransferTo(_itemHolder))
            {
                playerThatActivated.ItemHolder.TransferTo(_itemHolder);
                _currentRecipe = _workbenchData._recipes.GetRecipeFor(_itemHolder.AllItems);
            }
        }

        private void ChangeRecipeFor(Recipe recipe)
        {
            _currentRecipe = recipe;
            _currentRecipeCompletion = 0f;
        }
    }
}