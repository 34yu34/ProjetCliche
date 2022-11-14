using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Items/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] private List<Item> _inputItems;
        [SerializeField] private Item _outputItem;
        [SerializeField] private GameObject _recipeAnimation;
        [SerializeField] private float _recipeCompletionTime;

        public List<Item> InputItems => _inputItems;
        public Item OutputItem => _outputItem;
        public GameObject RecipeAnimation => _recipeAnimation;
        
        
        private static Recipe _nullRecipe;

        public static Recipe NullRecipe
        {
            get
            {
                if (_nullRecipe is not null) return _nullRecipe;
                
                SetupNullRecipe();

                return _nullRecipe;
            }
        }

        private static void SetupNullRecipe()
        {
            _nullRecipe = CreateInstance<Recipe>();

            _nullRecipe._inputItems = new List<Item>(0);
            _nullRecipe._outputItem = Item.NullItem;
            _nullRecipe._recipeAnimation = null;
            _nullRecipe.name = "NullRecipe";
        }

        public bool IsNull()
        {
            return this == _nullRecipe;
        }
    }
}