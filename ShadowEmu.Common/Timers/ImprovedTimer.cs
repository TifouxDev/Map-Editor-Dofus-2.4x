using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ShadowEmu.Common.Timers
{
    public class ImprovedTimer
    {
        private Timer _timer;
        private Stopwatch _stopWatch;
        private bool _paused;
        private double _interval;
        private double _remainingTimeBeforePause;

        public ImprovedTimer(double interval, ElapsedEventHandler handler)
        {
            _interval = interval;
            _stopWatch = new Stopwatch();

            _timer = new Timer(interval);
            _timer.Elapsed += (sender, arguments) => {
                if (handler != null)
                {
                    if (_timer.AutoReset)
                    {
                        _stopWatch.Restart();
                    }

                    handler(sender, arguments);
                }
            };

            _timer.AutoReset = false;
        }

        public bool AutoReset
        {
            get
            {
                return _timer.AutoReset;
            }
            set
            {
                _timer.AutoReset = value;
            }
        }

        public void Start()
        {
            _timer.Start();
            _stopWatch.Restart();
        }

        public void Stop()
        {
            _timer.Stop();
            _stopWatch.Stop();
        }

        public void Pause()
        {
            if (!_paused && _timer.Enabled)
            {
                _stopWatch.Stop();
                _timer.Stop();
                _remainingTimeBeforePause = Math.Max(0, _interval - _stopWatch.ElapsedMilliseconds);
                _paused = true;
            }
        }

        public void Resume()
        {
            if (_paused)
            {
                _paused = false;
                if (_remainingTimeBeforePause > 0)
                {
                    _timer.Interval = _remainingTimeBeforePause;
                    _timer.Start();
                }
            }
        }
    }
}
