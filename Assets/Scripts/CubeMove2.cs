using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using Unity.VisualScripting;

public class CubeMove2 : MonoBehaviour
{
    private Coroutine _moveCoroutine;
    [SerializeField] float speed = 20f;
    bool _coroutineActive = false;
    bool isActive;
    
    public void StartMoveCube()
    {
        if (!_coroutineActive)
        {
            isActive = false;
            MoveAsync();
            _coroutineActive = true;
            
        }
    }

    public void StopMoveCube()
    {
        _coroutineActive = false;
        isActive = true;
    }

    async UniTask MoveAsync()
    {
        for(int i = 0; i < 1000; i++)
        {
            transform.rotation *= Quaternion.Euler(20, speed, 20);
            await UniTask.WaitUntil(() => isActive == false);
        }
        _coroutineActive = false;
    }
}
