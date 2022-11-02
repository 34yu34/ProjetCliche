using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    private static TimerService _instance;

    public static TimerService Instance
    {
        get
        {
            if (_instance is not null) return _instance;
            
            _instance = FindObjectOfType<TimerService>();
                
            Debug.Assert(_instance is not null, "Must have a timer service in scene");

            return _instance;
        }
    }

    private List<Timer> _timers;

    private void Awake()
    {
        _timers = new List<Timer>();
    }

    public void Update()
    {
        foreach (var timer in _timers)
        {
           timer.Update();
        }
    }

    public void RegisterTimer(Timer timer)
    {
        if (_timers.Contains(timer))
        {
            return;
        }
        _timers.Add(timer);
    }

    public void UnregisterTimer(Timer timer)
    {
        _timers.Remove(timer);
    }
}