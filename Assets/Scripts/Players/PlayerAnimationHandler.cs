using System;
using Helpers;
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

        [SerializeField] private Timer _walkingTimer;

        private bool _lastIsWalking;
        
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
            SetupDirectionAnimFlag();
            SetupWalkingTimer();
        }

        private void SetupDirectionAnimFlag()
        {
            _player._directionChangeEvent.AddListener(SetDirection);
            SetDirection(_player.Direction);
        }
        
        private void SetupWalkingTimer()
        {
            _walkingTimer._onTimerCompleted.AddListener(ChangeWalkingAnimFlag);
            _lastIsWalking = _player.IsWalking;
            ChangeWalkingAnimFlag();
        }

        public void Update()
        {
            UpdateWalkingChecks();
            
            _animator.SetFloat(Speed, _player.MovementSpeed);
        }

        private void UpdateWalkingChecks()
        {
            if (_lastIsWalking == _player.IsWalking) return;
            
            _walkingTimer.Start();
            _lastIsWalking = _player.IsWalking;
        }

        private void SetDirection(Vector2 newDirection)
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
            
            _animator.SetInteger(Side, (int)_direction);
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

        private void ChangeWalkingAnimFlag()
        {
            _animator.SetBool(IsWalking, _player.IsWalking);
        }
    }
}