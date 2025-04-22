using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TaskQueueStudy : MonoBehaviour
{
    private readonly TaskQueue taskQueue = new();
    private int foo = 0;
    private int fo = 0;

    async void Start()
    {
        taskQueue.RunTaskForget(async () =>
        {
            for (var i = 0; i < 10; i++)
            {
                Debug.LogWarning($"Task {i}");
                await UniTask.Yield();
            }
            
            return 30;
        }, (forgetRunResult) =>
        {
            fo = forgetRunResult;
        });
        // foo = await taskQueue.RunTask(async () =>
        // {
        //     Debug.LogWarning("Start Foo");
        //     await UniTask.Delay(5000);
        //     Debug.LogWarning("End Foo");
        //     
        //     return 40;
        // });        
        Debug.Log("----------------------------------------------------------------------------------------------------------");
        //값이 할당 되기도 전에 유니티 실행큐에 Update()가 들어가서 실행 중이여서, 한 프레임 더 도는 것이다.
        foo = await taskQueue.RunTask(async () =>
        {
            Debug.LogWarning("Start Foo");
            await UniTask.Delay(5000);
            Debug.LogWarning("End Foo");
            
            return 40;
        });
        // taskQueue.RunTaskForget(async () =>
        // {
        //     for (var i = 0; i < 10; i++)
        //     {
        //         Debug.LogWarning($"Task {i}");
        //         await UniTask.Yield();
        //     }
        //     
        //     return 30;
        // }, (onComplete) =>
        // {
        //     fo = onComplete;
        // });
    }

    void Update()
    {
        if (fo != 30)
        {
            Debug.LogError("Wait Fo");
        }
        if (foo != 40)
        {
            Debug.LogError("foo");
        }
    }
}
