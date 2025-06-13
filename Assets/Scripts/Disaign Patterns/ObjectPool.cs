using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool
{
    private GameObject[] _pool;


    public ObjectPool(int size, GameObject target, GameObject parent) 
    {
        CreatePooledObject(size, target, parent);
    }

    private void CreatePooledObject(int size, GameObject target, GameObject parent )
    {
        _pool = new GameObject[size];

        for (int i = 0; i < size; i++) 
        {
            GameObject obj = MonoBehaviour.Instantiate(target, parent.transform);
            _pool[i] = obj;
            _pool[i].SetActive(true);
        }
    }

    public void Activate(bool select)
    {
        foreach (var element in _pool)
        {
            if (element.activeSelf != select)
            {
                element.SetActive(select);
                return;
            }
        }
    }

    public void DestroyAll()
    {
        foreach(var element in _pool)
        {
            if (element != null)
                MonoBehaviour.Destroy(element);
        }
        _pool = null;
    }
}