using System;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private Player _player;
        private Animator _animator;

        private Direction _direction;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int Side = Animator.StringToHash("Side");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private enum Direction
        {
            Down = 0,
            Side = 1,
            Top = 2
        }
        
        private void Awake()
        {
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _player._directionChangeEvent.AddListener(GetDirection);
        }

        public void Update()
        {
            _animator.SetBool(IsWalking, _player.IsWalking);
            _animator.SetInteger(Side, (int)_direction);
            _animator.SetFloat(Speed, _player.MovementSpeed);
        }

        public void GetDirection(Vector2 newDirection)
        {
            if (newDirection == Vector2.down)
            {
                _direction = Direction.Down;
            }
            else if (newDirection == Vector2.up)
            {
                _direction = Direction.Top;
            }
            else
            {
                _direction = Direction.Side;

                SetupSideDirection();
            }
        }

        private void SetupSideDirection()
        {
            if (_player.Direction.x < 0)
            {
                var transformLocalScale = _player.transform.localScale;
                transformLocalScale.x = -Math.Abs(transformLocalScale.x);
                _player.transform.localScale = transformLocalScale;
            }
            else
            {
                var transformLocalScale = _player.transform.localScale;
                transformLocalScale.x = Math.Abs(transformLocalScale.x);
                _player.transform.localScale = transformLocalScale;
            }
        }
    }
}