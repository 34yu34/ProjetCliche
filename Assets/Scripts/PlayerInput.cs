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

        [InputAxis]
        [SerializeField] 
        private string _interactInput;

        
        public Vector2 MovementInput { get; private set; }
        public bool HasInteractActive { get; private set; }

        private void Update()
        {
            MovementInput = new Vector2(Input.GetAxis(_horizontalInput), Input.GetAxis(_verticalInput));

            HasInteractActive = Input.GetButtonDown(_interactInput);
        }
    }
}