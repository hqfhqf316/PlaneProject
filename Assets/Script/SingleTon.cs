using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : Component
{

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (Instance == null)
                {
                    Debug.LogWarning("An instance of" + typeof(T) + "is needed in the scene,but there is none.");
                     GameObject obj = new GameObject();
                    instance = obj.AddComponent<T>();
                }
            }

            return instance;
        }

    }
    protected static T instance;
    protected virtual void Awake()
    {
        instance = this as T;
    }
}
