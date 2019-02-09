using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Thread
{
    public static class TaskExtensions
    {
        private class CancelOnDispose : IDisposable
        {
            internal CancellationTokenSource Source;

            void IDisposable.Dispose()
            {
                this.Source.Cancel();
            }
        }

        private class TaskObservable<TResult> : IObservable<TResult>
        {
            internal Task<TResult> Task;

            public IDisposable Subscribe(IObserver<TResult> observer)
            {
                if (observer == null)
                {
                    throw new ArgumentNullException("observer");
                }
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                this.Task.ContinueWith(delegate (Task<TResult> t)
                {
                    switch (t.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            observer.OnNext(this.Task.Result);
                            observer.OnCompleted();
                            break;

                        case TaskStatus.Canceled:
                            observer.OnError(new TaskCanceledException(t));
                            break;

                        case TaskStatus.Faulted:
                            observer.OnError(this.Task.Exception);
                            break;
                    }
                }, cancellationTokenSource.Token);
                return new TaskExtensions.CancelOnDispose
                {
                    Source = cancellationTokenSource
                };
            }
        }

        public static Task ContinueWith(this Task task, Action<Task> continuationAction, TaskFactory factory)
        {
            return task.ContinueWith(continuationAction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        public static Task<TResult> ContinueWith<TResult>(this Task task, Func<Task, TResult> continuationFunction, TaskFactory factory)
        {
            return task.ContinueWith<TResult>(continuationFunction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        public static Task ContinueWith<TResult>(this Task<TResult> task, Action<Task<TResult>> continuationAction, TaskFactory<TResult> factory)
        {
            return task.ContinueWith(continuationAction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        public static Task<TNewResult> ContinueWith<TResult, TNewResult>(this Task<TResult> task, Func<Task<TResult>, TNewResult> continuationFunction, TaskFactory<TResult> factory)
        {
            return task.ContinueWith<TNewResult>(continuationFunction, factory.CancellationToken, factory.ContinuationOptions, factory.Scheduler);
        }

        public static Task ToAsync(this Task task, AsyncCallback callback, object state)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(state);
            task.ContinueWith(delegate (Task _)
            {
                tcs.SetFromTask(task);
                if (callback != null)
                {
                    callback(tcs.Task);
                }
            });
            return tcs.Task;
        }

        public static Task<TResult> ToAsync<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }
            TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>(state);
            task.ContinueWith(delegate (Task<TResult> _)
            {
                tcs.SetFromTask(task);
                if (callback != null)
                {
                    callback(tcs.Task);
                }
            });
            return tcs.Task;
        }

        public static Task IgnoreExceptions(this Task task)
        {
            return task.ContinueWith(delegate (Task t)
            {
                AggregateException arg_06_0 = t.Exception;
            }, CancellationToken.None, TaskContinuationOptions.NotOnRanToCompletion | TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        public static Task<T> IgnoreExceptions<T>(this Task<T> task)
        {
            return (Task<T>)task.IgnoreExceptions();
        }

        public static Task FailFastOnException(this Task task)
        {
            task.ContinueWith(delegate (Task t)
            {
                Environment.FailFast("A task faulted.", t.Exception);
            }, CancellationToken.None, TaskContinuationOptions.NotOnRanToCompletion | TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            return task;
        }

        public static Task<T> FailFastOnException<T>(this Task<T> task)
        {
            return (Task<T>)task.FailFastOnException();
        }

        public static void PropagateExceptions(this Task task)
        {
            if (!task.IsCompleted)
            {
                throw new InvalidOperationException("The task has not completed.");
            }
            if (task.IsFaulted)
            {
                task.Wait();
            }
        }

        public static void PropagateExceptions(this Task[] tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException("tasks");
            }
            if (tasks.Any((Task t) => t == null))
            {
                throw new ArgumentException("tasks");
            }
            if (tasks.Any((Task t) => !t.IsCompleted))
            {
                throw new InvalidOperationException("A task has not completed.");
            }
            Task.WaitAll(tasks);
        }

        public static void AttachToParent(this Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }
            task.ContinueWith(delegate (Task t)
            {
                t.Wait();
            }, CancellationToken.None, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        public static Task WithTimeout(this Task task, TimeSpan timeout)
        {
            TaskCompletionSource<object> result = new TaskCompletionSource<object>(task.AsyncState);
            Timer timer = new Timer(delegate (object state)
            {
                ((TaskCompletionSource<object>)state).TrySetCanceled();
            }, result, timeout, TimeSpan.FromMilliseconds(-1.0));
            task.ContinueWith(delegate (Task t)
            {
                timer.Dispose();
                result.TrySetFromTask(t);
            }, TaskContinuationOptions.ExecuteSynchronously);
            return result.Task;
        }

        public static Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            TaskCompletionSource<TResult> result = new TaskCompletionSource<TResult>(task.AsyncState);
            Timer timer = new Timer(delegate (object state)
            {
                ((TaskCompletionSource<TResult>)state).TrySetCanceled();
            }, result, timeout, TimeSpan.FromMilliseconds(-1.0));
            task.ContinueWith(delegate (Task<TResult> t)
            {
                timer.Dispose();
                result.TrySetFromTask(t);
            }, TaskContinuationOptions.ExecuteSynchronously);
            return result.Task;
        }

        public static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }
            return new TaskExtensions.TaskObservable<TResult>
            {
                Task = task
            };
        }

        public static TaskStatus WaitForCompletionStatus(this Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }
            ((IAsyncResult)task).AsyncWaitHandle.WaitOne();
            return task.Status;
        }
    }
}
