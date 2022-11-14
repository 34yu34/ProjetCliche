using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "RecipeBook", menuName = "Items/RecipeBook", order = 0)]
    public class RecipesBook : ScriptableObject
    {
        [SerializeField] private List<Recipe> _recipes;

        public Recipe GetRecipeFor(IEnumerable<Item> inputsItem)
        {
            foreach (var recipe in _recipes.Where(recipe => recipe.InputItems.SequenceEqual(inputsItem)))
            {
                return recipe;
            }

            return Recipe.NullRecipe;
        }

        public List<Recipe> GetAllRecipeFor(Item inputItem)
        {
            return _recipes.Where(recipe => recipe.InputItems.Contains(inputItem)).ToList();
        }
    } 
}