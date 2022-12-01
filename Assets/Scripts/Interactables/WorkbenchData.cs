using Items;
using UnityEngine;

namespace Interactables
{
    [CreateAssetMenu(fileName = "WorkBenchData", menuName = "Data/WorkbenchData", order = 0)]
    public class WorkbenchData : ScriptableObject
    {
        public float _playerCompletionSpeed;

        public float _automationCompletionSpeed;

        public RecipesBook _recipes;
    }
}