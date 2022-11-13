using System;
using Helpers;
using Interactables;
using Items;
using NaughtyAttributes.Test;
using UnityEngine;
using UnityEngine.Events;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(ItemHolder))]
    [RequireComponent(typeof(PlayerAnimationHandler))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [SerializeField] private float _viewDist;

        private Rigidbody2D _rb;
        private PlayerInput _inputs;
        private ItemHolder _holder;

        [SerializeField] private Interactable _currentInteractable;
        public ItemHolder ItemHolder => _holder;
        
        private Vector2 _direction;
        public Vector2 Direction => _direction;

        public bool IsWalking => _inputs.MovementInput != Vector2.zero; 
    
        [HideInInspector] 
        public UnityEvent<Vector2> _directionChangeEvent;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputs = GetComponent<PlayerInput>();
            _holder = GetComponent<ItemHolder>();
            _direction = Vector2.right;
            _directionChangeEvent.AddListener(ResetInteractable);
        }

        public void Update()
        {
            ActivateInteractable();
        }

        public void FixedUpdate()
        {
            _rb.velocity = _inputs.MovementInput * _movementSpeed;

            LookForNewDirection();
        
            CheckForwardInteractables();
        }
        
        private void LookForNewDirection()
        {
            var last_dir = _direction;
            
            _direction = FindNextDirection();

            if (last_dir != _direction)
            {
                _directionChangeEvent.Invoke(_direction);
            }
        }

        private Vector2 FindNextDirection()
        {
            if (_inputs.MovementInput != Vector2.zero)
            {
                _direction = Math.Abs(_inputs.MovementInput.x) > Math.Abs(_inputs.MovementInput.y)
                    ? new Vector2(_inputs.MovementInput.x, 0)
                    : new Vector2(0, _inputs.MovementInput.y);
                _direction.Normalize();
            }

            return _direction;
        }

        private void CheckForwardInteractables()
        {
            if (_currentInteractable is not null) return;
            
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
                _currentInteractable.ActivityInteract(this);
            }

            if (_inputs.ItemButtonPressed)
            {
                _currentInteractable.ItemInteract(this);
            }

            var interactableTransform = _currentInteractable.transform;
            CustomDebug.DrawBox(interactableTransform.position, _currentInteractable.BoxCollider.size * interactableTransform.localScale, _currentInteractable.IsActive ? Color.yellow : Color.green);
        }

        private void ResetInteractable(Vector2 newDirection)
        {
            _currentInteractable = null;
        }
    }
}
