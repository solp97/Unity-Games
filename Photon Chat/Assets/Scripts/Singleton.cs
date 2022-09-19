using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // where절 T의 대한 제약 조건 즉, 제네릭을 썼을때에만 사용가능, 제네릭은 일반화 프로그래밍 타입을 인자처럼 이용가능
//아무 타입이든 올 수 있다. 어떤 컴포넌트던지 간에 T는 모노비헤비어를 상속 받아야한다.
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }

        return _instance;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null)
        {
            if(_instance != this) Destroy(gameObject);

            return;
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
