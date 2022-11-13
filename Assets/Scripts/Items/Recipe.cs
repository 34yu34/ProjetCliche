using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Items/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] private Item[] _inputItems;

        [SerializeField] private Item _outputItem;

        [SerializeField] private GameObject _recipeAnimation;
    }
}