using System;
using System.Runtime.InteropServices.ComTypes;
using Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactables
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public class Door : MonoBehaviour
    {
        [SerializeField] private float _closeOpenSpeed;
        
        private Animator _doorAnimator;
        private Collider2D _collider;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        private void Awake()
        {
            _doorAnimator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
            Close();
        }
        
        public void Open()
        {
            _doorAnimator.SetBool(IsOpen, true);
        }

        public void Close()
        {
            _doorAnimator.SetBool(IsOpen, false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();
            if (player is not null)
            {
                Open();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.GetComponent<Player>();
            if (player is not null)
            {
                Close();
            }
        }
    }
}