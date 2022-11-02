using System;
using DefaultNamespace;
using UnityEngine;

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

    public void Update()
    {
        ActivateInteractable();
    }

    public void FixedUpdate()
    {
        _rb.velocity = _inputs.MovementInput * _movementSpeed;

        SetupDirection();
        
        CheckForward();
    }


    private void SetupDirection()
    {
        if (_inputs.MovementInput != Vector2.zero)
        {
            _direction = Math.Abs(_inputs.MovementInput.x) > Math.Abs(_inputs.MovementInput.y)
                ? new Vector2(_inputs.MovementInput.x, 0)
                : new Vector2(0, _inputs.MovementInput.y);
            _direction.Normalize();
        }
    }

    private void CheckForward()
    {
        _currentInteractable = null;
        
        var position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(position.x, position.y), _direction, _viewDist, 1 << Interactable.InteractableLayer);
        
        CustomDebug.DrawLine(position,_direction, _viewDist, Color.red);

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
        CustomDebug.DrawBox(_currentInteractable.transform.position, _currentInteractable.BoxCollider.size, Color.green);
    }
    
    
    private void ActivateInteractable()
    {
        if (_currentInteractable is null)
        {
            return;
        }
        
        if (_inputs.HasInteractActive)
        {
            _currentInteractable.Interact();
        }

        CustomDebug.DrawBox(_currentInteractable.transform.position, _currentInteractable.BoxCollider.size, _currentInteractable.IsActive ? Color.yellow : Color.green);
    }
}
