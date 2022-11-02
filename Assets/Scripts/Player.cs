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

    private Vector2 _direction;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = GetComponent<PlayerInput>();
        _direction = Vector2.right;
    }

    public void FixedUpdate()
    {
        _rb.velocity = _inputs.MovementInput * _movementSpeed;

        if (_inputs.MovementInput != Vector2.zero)
        {
            _direction = _inputs.MovementInput.normalized;
        }
        
        LookForward();
    }

    private void LookForward()
    {
        
        _currentInteractable = null;
        
        var position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(position.x, position.y), _direction, _viewDist, 1 << Interactable.InteractableLayer);
        
        #if UNITY_EDITOR
            Debug.DrawLine(position, position + (Vector3)_direction * _viewDist, Color.red);
        #endif

        if (!hit)
        {
            return;
        }

        var interactable = hit.collider.GetComponent<Interactable>();

        if (!interactable)
        {
            return;
        }

        _currentInteractable = interactable;
    }
}
