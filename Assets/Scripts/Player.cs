using DefaultNamespace;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _viewDist;
    
    private Rigidbody2D _rb;
    private PlayerInput _inputs;

    [SerializeField] private Interactable _currentInteractable;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = GetComponent<PlayerInput>();
    }

    public void FixedUpdate()
    {
        _rb.velocity = _inputs.MovementInput * _movementSpeed;
        
        LookForward();
    }

    private void LookForward()
    {
        var position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(position.x, position.y), _inputs.MovementInput, _viewDist, 1 << Interactable.InteractableLayer);
        
        if (hit)
        {
            var interactable = hit.collider.GetComponent<Interactable>();

            if (interactable)
            {
                _currentInteractable = interactable;
            }
        }
        else
        {
            _currentInteractable = null;
        }
    }
}
