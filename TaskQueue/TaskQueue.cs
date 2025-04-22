using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

//UniTask 라이브러리가 필요합니다.

public class TaskQueue
{
    private readonly Queue<Func<UniTask>> _taskQueue = new();
    private readonly object _lock = new();
    private bool _isProcessing = false;

    public void RunTaskForget<T>(Func<UniTask<T>> task, Action<T> onComplete = null)
    {
        lock (_lock)
        {
            _taskQueue.Enqueue(async () =>
            {
                try
                {
                    var result = await UniTask.RunOnThreadPool(task);
                    
                    onComplete?.Invoke(result);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
                finally
                {
                    await DoneTask();
                }
            });
        
            if (_isProcessing is false)
            {
                _isProcessing = true;
                _taskQueue.Dequeue().Invoke();
            }
        }
    }
    
    public UniTask<T> RunTask<T>(Func<UniTask<T>> task)
    {
        var source = new UniTaskCompletionSource<T>();
        
        lock (_lock)
        {
            _taskQueue.Enqueue(async () =>
            {
                try
                {
                    var result = await UniTask.RunOnThreadPool(task);
        
                    source.TrySetResult(result);
                }
                catch (Exception e)
                {
                    source.TrySetException(e);
                }
                finally
                {
                    await DoneTask();
                }
            });
        
            if (_isProcessing is false)
            {
                _isProcessing = true;
                _taskQueue.Dequeue().Invoke();
            }
        }
        
        return source.Task;
    }

    public async UniTask DoneTask()
    {
        Func<UniTask> lockTask = null;

        lock (_lock)
        {
            _isProcessing = false;
        
            //등록된 작업이 없는데 DoneTask()하는 경우
            if (_taskQueue.Count <= 0) return;
        
            _isProcessing = true;

            lockTask = _taskQueue.Dequeue();
        }
        
        if(lockTask is not null)
            await UniTask.RunOnThreadPool(lockTask);
    }
}
