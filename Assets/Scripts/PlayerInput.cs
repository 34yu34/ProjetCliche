using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        [InputAxis]
        [SerializeField] 
        private string _horizontalInput;
    
        [InputAxis]
        [SerializeField] 
        private string _verticalInput;

        public Vector2 MovementInput { get; private set; }

        private void Update()
        {
            MovementInput = new Vector2(Input.GetAxis(_horizontalInput), Input.GetAxis(_verticalInput));
        }
    }
}