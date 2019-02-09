using ShadowEmu.Common.Extensions;
using ShadowEmu.Common.Timers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Thread
{
    public class SelfRunningTaskPool
    {
        private readonly Stopwatch m_queueTimer;
        private readonly List<SimpleTimerEntry> m_simpleTimers;
        private readonly ManualResetEvent m_stoppedAsync = new ManualResetEvent(false);
        private readonly List<TimerEntry> m_timers;
        private int m_currentThreadId;
        private int m_lastUpdate;
        private Task m_updateTask;
        public string Name
        {
            get;
            set;
        }
        public int UpdateInterval
        {
            get;
            set;
        }
        public long LastUpdateTime
        {
            get
            {
                return (long)m_lastUpdate;
            }
        }
        public bool IsRunning
        {
            get;
            protected set;
        }
        public ReadOnlyCollection<TimerEntry> Timers
        {
            get
            {
                return m_timers.AsReadOnly();
            }
        }
        public ReadOnlyCollection<SimpleTimerEntry> SimpleTimers
        {
            get
            {
                return m_simpleTimers.AsReadOnly();
            }
        }
        public bool IsInContext
        {
            get
            {
                return System.Threading.Thread.CurrentThread.ManagedThreadId == m_currentThreadId;
            }
        }

        public SelfRunningTaskPool(int interval, string name)
        {
            m_queueTimer = Stopwatch.StartNew();
            m_simpleTimers = new List<SimpleTimerEntry>();
            m_timers = new List<TimerEntry>();
            UpdateInterval = interval;
            Name = name;
            Start();
        }


        public void Start()
        {
            IsRunning = true;
            m_updateTask = Task.Factory.StartNewDelayed(UpdateInterval, new Action<object>(ProcessCallback), this);
        }

        public void Stop(bool async = false)
        {
            IsRunning = false;
            if (async && m_currentThreadId != 0)
            {
                m_stoppedAsync.WaitOne();
            }
        }

        public void EnsureNotContext()
        {
            if (IsInContext)
            {
                throw new InvalidOperationException("Forbidden context");
            }
        }

     
        public void CancelSimpleTimer(SimpleTimerEntry timer)
        {
            m_simpleTimers.Remove(timer);
        }

        public SimpleTimerEntry CallPeriodically(int delayMillis, Action callback)
        {
            SimpleTimerEntry simpleTimerEntry = new SimpleTimerEntry(delayMillis, callback, LastUpdateTime, false);
            m_simpleTimers.Add(simpleTimerEntry);
            return simpleTimerEntry;
        }

        public SimpleTimerEntry CallDelayed(double delayMillis, Action callback)
        {
            SimpleTimerEntry simpleTimerEntry = new SimpleTimerEntry(delayMillis, callback, LastUpdateTime, true);
            m_simpleTimers.Add(simpleTimerEntry);
            return simpleTimerEntry;
        }

        public double GetDelayUntilNextExecution(SimpleTimerEntry timer)
        {
            return timer.Delay - (LastUpdateTime - timer.LastCallTime);
        }

        protected void ProcessCallback(object state)
        {
            if (IsRunning && Interlocked.CompareExchange(ref m_currentThreadId ,System.Threading.Thread.CurrentThread.ManagedThreadId, 0) == 0)
            {
                long num = 0L;
                try
                {
                    num = m_queueTimer.ElapsedMilliseconds;
                    int dtMillis = (int)(num - (long)m_lastUpdate);
                    m_lastUpdate = (int)num;
                    foreach (TimerEntry current in m_timers)
                    {
                        try
                        {
                            current.Update(dtMillis);
                        }
                        catch (Exception argument)
                        {
                           // SelfRunningTaskPool.logger.Error<TimerEntry, Exception>("Failed to update {0} : {1}", current, argument);
                        }
                        if (!IsRunning)
                        {
                            return;
                        }
                    }
                    int count = m_simpleTimers.Count;
                    int num2 = count - 1;
                    while (num2 >= 0)
                    {
                        SimpleTimerEntry simpleTimerEntry = m_simpleTimers[num2];
                        if (GetDelayUntilNextExecution(simpleTimerEntry) > 0)
                        {
                            goto IL_107;
                        }
                        try
                        {
                            simpleTimerEntry.Execute(this);
                            goto IL_107;
                        }
                        catch (Exception argument)
                        {
                        //    SelfRunningTaskPool.logger.Error<SimpleTimerEntry, Exception>("Failed to execute timer {0} : {1}", simpleTimerEntry, argument);
                            goto IL_107;
                        }
                    IL_FF:
                        num2--;
                        continue;
                    IL_107:
                        if (!IsRunning)
                        {
                            return;
                        }
                        goto IL_FF;
                    }               
                }
                catch (Exception argument)
                {
                  //  SelfRunningTaskPool.logger.Error<string, Exception>("Failed to run TaskQueue callback for \"{0}\" : {1}", Name, argument);
                }
                finally
                {
                    long elapsedMilliseconds = m_queueTimer.ElapsedMilliseconds;
                    bool flag;
                    long num3 = (flag = (elapsedMilliseconds - num > (long)UpdateInterval)) ? 0L : (num + (long)UpdateInterval - elapsedMilliseconds);
                    Interlocked.Exchange(ref m_currentThreadId, 0);
                    if (flag)
                    {
                   //     SelfRunningTaskPool.logger.Debug<string, long>("TaskPool '{0}' update lagged ({1}ms)", Name, elapsedMilliseconds - num);
                    }
                    if (IsRunning)
                    {
                        m_updateTask = Task.Factory.StartNewDelayed((int)num3, new Action<object>(ProcessCallback), this);
                    }
                    else
                    {
                        m_stoppedAsync.Set();
                    }
                }
            }
        }
    }
}
