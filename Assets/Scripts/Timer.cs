using System;
using UnityEngine;
using UnityEngine.Events;


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

    public void Update()
    {
        if (!IsRunning)
        {
            return;
        }

        if (!(Time.time > _endTimestamp)) return;
        
        _onTimerCompleted.Invoke();
        IsRunning = false;
    }

    public float RemainingTime()
    {
        if (!HasPass())
        {
            return _endTimestamp - Time.time;
        }

        return 0.0f;
    }

    private bool HasPass()
    {
        return Time.time > _endTimestamp;
    }

    public void Kill()
    {
        IsRunning = false;
        TimerService.Instance.UnregisterTimer(this);
    }
}