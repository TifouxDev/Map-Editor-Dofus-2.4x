using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Timers
{
    public class TimerEntry : IDisposable
    {
        private int m_millisSinceLastTick;
        private int m_millisBeforeInit;
        private int m_initialDelay;
        public Action<int> Action;
        public int InitialDelay
        {
            get
            {
                return this.m_initialDelay;
            }
            set
            {
                this.m_initialDelay = value;
                this.m_millisBeforeInit = value;
            }
        }
        public int IntervalDelay
        {
            get;
            set;
        }
        public int MillisSinceLastTick
        {
            get
            {
                return this.m_millisSinceLastTick;
            }
        }
        public int RemainingTime
        {
            get
            {
                return (this.m_millisBeforeInit > 0) ? this.m_millisBeforeInit : (this.IntervalDelay - this.m_millisSinceLastTick);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.m_millisSinceLastTick >= 0;
            }
        }

        public TimerEntry()
        {
        }

        public TimerEntry(int delay, int intervalDelay, Action<int> callback)
        {
            this.m_millisSinceLastTick = -1;
            this.Action = callback;
            this.InitialDelay = delay;
            this.IntervalDelay = intervalDelay;
        }

        public TimerEntry(Action<int> callback)
            : this(0, 0, callback)
        {
        }

        public void Start()
        {
            this.m_millisSinceLastTick = 0;
        }

        public void Start(int initialDelay)
        {
            this.InitialDelay = initialDelay;
            this.m_millisSinceLastTick = 0;
        }

        public void Start(int initialDelay, int interval)
        {
            this.InitialDelay = initialDelay;
            this.IntervalDelay = interval;
            this.m_millisSinceLastTick = 0;
        }

        public void Stop()
        {
            this.m_millisSinceLastTick = -1;
        }

        public void Update(int dtMillis)
        {
            if (this.m_millisSinceLastTick != -1)
            {
                if (this.m_millisBeforeInit > 0)
                {
                    this.m_millisBeforeInit -= dtMillis;
                    if (this.m_millisBeforeInit <= 0)
                    {
                        if (this.IntervalDelay == 0)
                        {
                            int millisSinceLastTick = this.m_millisSinceLastTick;
                            this.Stop();
                            this.Action(millisSinceLastTick);
                        }
                        else
                        {
                            this.Action(this.m_millisSinceLastTick);
                            this.m_millisSinceLastTick = 0;
                        }
                    }
                }
                else
                {
                    this.m_millisSinceLastTick += dtMillis;
                    if (this.m_millisSinceLastTick >= this.IntervalDelay)
                    {
                        this.Action(this.m_millisSinceLastTick);
                        if (this.m_millisSinceLastTick != -1)
                        {
                            this.m_millisSinceLastTick -= this.IntervalDelay;
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            this.Stop();
            this.Action = null;
        }

        public override bool Equals(object obj)
        {
            return !(obj.GetType() != typeof(TimerEntry)) && this.Equals((TimerEntry)obj);
        }

        public bool Equals(TimerEntry obj)
        {
            return obj.IntervalDelay == this.IntervalDelay && object.Equals(obj.Action, this.Action);
        }

        public override int GetHashCode()
        {
            return this.IntervalDelay * 397 ^ ((this.Action != null) ? this.Action.GetHashCode() : 0);
        }
    }
}
