using System;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _duration;
    
        public bool IsRunning { get; private set; }

        private float _endTimestamp;

        public UnityEvent _onTimerCompleted;

        public void Start()
        {
            IsRunning = true;
            _endTimestamp = Time.time + _duration;
            TimerService.Instance.RegisterTimer(this);
        }
        public float RemainingTime()
        {
            if (!IsTimerDone())
            {
                return _endTimestamp - Time.time;
            }

            return 0.0f;
        }

        public void Update()
        {
            CheckTimerCompletion();
        }

        private void CheckTimerCompletion()
        {
            if (!IsRunning) return;

            if (!IsTimerDone()) return;

            TimerCompleted();
        }

        private void TimerCompleted()
        {
            _onTimerCompleted.Invoke();
            IsRunning = false;
            TimerService.Instance.UnregisterTimer(this);
        }

        private bool IsTimerDone()
        {
            return Time.time >= _endTimestamp;
        }

        public void Kill()
        {
            IsRunning = false;
            TimerService.Instance.UnregisterTimer(this);
        }
    }
}