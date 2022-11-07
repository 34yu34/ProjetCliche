using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers
{
    public class TimerService : Service<TimerService>
    {
        private List<Timer> _runningTimers;
        private List<Timer> _timersToRemove;

        private void Awake()
        {
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