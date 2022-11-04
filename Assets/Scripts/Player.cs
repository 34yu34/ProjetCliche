using System;
using Helpers;
using Interactables;
using Items;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(ItemHolder))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    [SerializeField] private float _viewDist;

    private Rigidbody2D _rb;
    private PlayerInput _inputs;
    private ItemHolder _holder;

    [SerializeField] private Interactable _currentInteractable;

    private Vector2 _direction;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = GetComponent<PlayerInput>();
        _holder = GetComponent<ItemHolder>();
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
        
        CheckForwardInteractables();
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

    private void CheckForwardInteractables()
    {
        _currentInteractable = PhysicsFinder.RaycastFind<Interactable>(
            transform.position,
            _direction,
            _viewDist,
            LayerMask.GetMask(Interactable.InteractableLayerName)
    );
}

    private void ActivateInteractable()
    {
        if (_currentInteractable is null) return;
        
        if (_inputs.InteractButtonPressed)
        {
            _currentInteractable.Interact();
        }

        CustomDebug.DrawBox(_currentInteractable.transform.position, _currentInteractable.BoxCollider.size, _currentInteractable.IsActive ? Color.yellow : Color.green);
    }
}
