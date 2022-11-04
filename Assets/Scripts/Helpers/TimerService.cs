using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers
{
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

        private List<Timer> _runningTimers;
        private List<Timer> _timersToRemove;

        private void Awake()
        {
            _instance = FindObjectOfType<TimerService>();
            
            _runningTimers = new List<Timer>();
            _timersToRemove = new List<Timer>();
        }

        private void Update()
        {
            foreach (var timer in _runningTimers)
            {
                timer.Update();
            }

            _runningTimers = _runningTimers.Except(_timersToRemove).ToList();
            _timersToRemove.Clear();
        }

        public void RegisterTimer(Timer timer)
        {
            if (_runningTimers.Contains(timer))
            {
                return;
            }
            _runningTimers.Add(timer);
        }

        public void UnregisterTimer(Timer timer)
        {
            _timersToRemove.Add(timer);
        }
    }
}