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
                _itemHolder.RemoveAll();
                _itemHolder.GiveItem(_currentRecipe.OutputItem);
                ChangeRecipeByInputItems();
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
                ChangeRecipeByInputItems();
                return;
            }

            if (playerThatActivated.ItemHolder.CanTransferTo(_itemHolder))
            {
                playerThatActivated.ItemHolder.TransferTo(_itemHolder);
                ChangeRecipeByInputItems();
            }
        }

        private void ChangeRecipeByInputItems()
        {
            _currentRecipe = _workbenchData._recipes.GetRecipeFor(_itemHolder.AllItems);
            _currentRecipeCompletion = 0f;
        }
    }
}