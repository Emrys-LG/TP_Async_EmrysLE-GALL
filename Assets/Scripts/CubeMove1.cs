using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using Unity.VisualScripting;

public class CubeMove1 : MonoBehaviour
{
    private Coroutine _moveCoroutine;
    [SerializeField] float speed = 20f;
    bool _coroutineActive = false;
    
    public void StartMoveCube()
    {
        if (!_coroutineActive)
        {
            _coroutineActive = true;
            _moveCoroutine =  StartCoroutine(MoveCoroutine());
            
            
        }
    }

    public void StopMoveCube()
    {
        _coroutineActive = false;
        StopCoroutine(_moveCoroutine);
        
    }

    private IEnumerator MoveCoroutine()
    {
        for(int i = 0; i < 100; i++)
        {
            transform.rotation *= Quaternion.Euler(20, speed, 20);
            yield return new WaitForSeconds(0.05f);
        }
        _coroutineActive = false;
    }
}
