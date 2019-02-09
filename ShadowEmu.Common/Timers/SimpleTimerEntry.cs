using ShadowEmu.Common.Thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Timers
{
    public class SimpleTimerEntry
    {
        public readonly bool IsOneShot;
        public long LastCallTime
        {
            get;
            private set;
        }
        public Action Callback
        {
            get;
            set;
        }
        public double Delay
        {
            get;
            set;
        }

        internal SimpleTimerEntry(double delayMillis, Action callback, long time, bool isOneShot)
        {
            this.Callback = callback;
            this.Delay = delayMillis;
            this.LastCallTime = time;
            this.IsOneShot = isOneShot;
        }

        internal void Execute(SelfRunningTaskPool queue)
        {
            if (BolBread)
                return;
            try
            {
                this.Callback();
            }
            finally
            {
                this.LastCallTime = queue.LastUpdateTime;
            }
            if (this.IsOneShot)
            {
                queue.CancelSimpleTimer(this);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SimpleTimerEntry && this.Callback == ((SimpleTimerEntry)obj).Callback;
        }

        public override int GetHashCode()
        {
            return this.Callback.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} (Callback = {1}, Delay = {2})", base.GetType(), this.Callback, this.Delay);
        }
        private bool BolBread = false;
        public void Stop()
        {
            BolBread = true;
        }
        public void Restart()
        {
            BolBread = false;
        }
    }
}
