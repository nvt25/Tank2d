using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Ins { get => instance; }
    protected virtual void Awake()
    {
        instance = (T)this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
