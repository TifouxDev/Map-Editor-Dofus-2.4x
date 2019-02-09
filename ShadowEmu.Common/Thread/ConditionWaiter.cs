using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ShadowEmu.Common.Thread
{
    public class ConditionWaiter
    {
        private readonly Func<bool> m_predicate;
        private readonly int m_timeout;
        private readonly System.Timers.Timer m_timer;
        private DateTime m_startTime;

        public event EventHandler Success;

        public event EventHandler Fail;

        public Func<bool> Predicate
        {
            get
            {
                return this.m_predicate;
            }
        }
        public int Interval
        {
            get;
            set;
        }
        public int Timeout
        {
            get
            {
                return this.m_timeout;
            }
        }

        public ConditionWaiter(Func<bool> predicate, int timeout)
            : this(predicate, timeout, 100)
        {
        }

        public ConditionWaiter(Func<bool> predicate, int timeout, int interval)
        {
            this.m_predicate = predicate;
            this.m_timeout = timeout;
            this.Interval = interval;
            this.m_timer = new System.Timers.Timer((double)interval);
            this.m_timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
        }

        public void Start()
        {
            if (this.m_startTime != default(DateTime))
            {
                this.m_startTime = DateTime.Now;
            }
            this.m_timer.Start();
        }

        public void Stop()
        {
            this.m_timer.Stop();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.m_timeout != -1 && (DateTime.Now - this.m_startTime).TotalMilliseconds > (double)this.m_timeout)
            {
                this.m_timer.Stop();
                if (this.Fail != null)
                {
                    this.Fail(this, new EventArgs());
                }
            }
            if (this.m_predicate())
            {
                this.m_timer.Stop();
                if (this.Success != null)
                {
                    this.Success(this, new EventArgs());
                }
            }
        }

        public static bool WaitFor(Func<bool> predicate, int timeout)
        {
            DateTime now = DateTime.Now;
            bool result;
            while (!predicate())
            {
                System.Threading.Thread.Sleep(100);
                if ((DateTime.Now - now).TotalMilliseconds >= (double)timeout)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public static bool WaitFor(Func<bool> predicate, int timeout, int interval)
        {
            DateTime now = DateTime.Now;
            bool result;
            while (!predicate())
            {
                System.Threading.Thread.Sleep(interval);
                if ((DateTime.Now - now).TotalMilliseconds >= (double)timeout && timeout != -1)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }
    }

    public class ConditionWaiter<T> where T : class
    {
        private readonly object[] m_delegateArgs;
        private readonly Func<bool> m_predicate;
        private readonly int m_timeout;
        private readonly System.Timers.Timer m_timer;
        private T m_delegateAction;
        private DateTime m_startTime;

        public event EventHandler Success;

        public event EventHandler Fail;

        public Func<bool> Predicate
        {
            get
            {
                return this.m_predicate;
            }
        }
        public int Interval
        {
            get;
            set;
        }
        public int Timeout
        {
            get
            {
                return this.m_timeout;
            }
        }
        public T DelegateAction
        {
            get
            {
                return this.m_delegateAction;
            }
            set
            {
                this.m_delegateAction = value;
            }
        }

        static ConditionWaiter()
        {
            if (!typeof(T).IsSubclassOf(typeof(Delegate)))
            {
                throw new InvalidOperationException(typeof(T).Name + " is not a delegate type");
            }
        }

        public ConditionWaiter(Func<bool> predicate, int timeout)
            : this(predicate, timeout, 100, default(T), new object[0])
        {
        }

        public ConditionWaiter(Func<bool> predicate, int timeout, int interval)
            : this(predicate, timeout, interval, default(T), new object[0])
        {
        }

        public ConditionWaiter(Func<bool> predicate, int timeout, int interval, T action, params object[] args)
        {
            this.m_predicate = predicate;
            this.m_timeout = timeout;
            this.Interval = interval;
            this.m_delegateAction = action;
            this.m_delegateArgs = args;
            this.m_timer = new System.Timers.Timer((double)interval);
            this.m_timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
        }

        public void Start()
        {
            if (this.m_startTime != default(DateTime))
            {
                this.m_startTime = DateTime.Now;
            }
            this.m_timer.Start();
        }

        public void Stop()
        {
            this.m_timer.Stop();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.m_timeout != -1 && (DateTime.Now - this.m_startTime).TotalMilliseconds > (double)this.m_timeout)
            {
                this.m_timer.Stop();
                if (this.Fail != null)
                {
                    this.Fail(this, new EventArgs());
                }
            }
            if (this.m_predicate())
            {
                this.m_timer.Stop();
                if (this.Success != null)
                {
                    this.Success(this, new EventArgs());
                }
                if (this.m_delegateAction != null)
                {
                    (this.m_delegateAction as Delegate).DynamicInvoke(this.m_delegateArgs);
                }
            }
        }
    }
}
