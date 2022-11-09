using NaughtyAttributes;
using UnityEngine;

namespace Players
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

        [InputAxis]
        [SerializeField] 
        private string _grabInput;
    
        public Vector2 MovementInput { get; private set; }
        public bool InteractButtonPressed { get; private set; }
        public bool GrabButtonPressed { get; private set; } 

        private void Update()
        {
            MovementInput = new Vector2(Input.GetAxis(_horizontalInput), Input.GetAxis(_verticalInput));

            InteractButtonPressed = Input.GetButtonDown(_interactInput);

            GrabButtonPressed = Input.GetButtonDown(_grabInput);
        }
    }
}