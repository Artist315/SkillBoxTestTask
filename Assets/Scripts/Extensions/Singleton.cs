using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<T>();
                if (!_instance)
                {
                    Debug.LogError($"Singleton of type {typeof(T)} not contains in scene");
                    return null;
                }

                (_instance as Singleton<T>).Initialize();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (!_instance)
        {
            _instance = GetComponent<T>();
            Initialize();
        }
        else if (_instance.gameObject != gameObject)
            Destroy(gameObject);
    }

    protected virtual void AwakeSingletone() { }

    protected virtual void Initialize() { }
}

public class SingletonNonMB<T> where T : class
{
    private static T instance = null;
    private static readonly object padlock = new object();

    public static T Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = (T)Activator.CreateInstance(typeof(T));
                }
                return instance;
            }
        }
    }
}
