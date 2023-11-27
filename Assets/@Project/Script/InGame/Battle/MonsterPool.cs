using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : SingletonBehaviour<MonsterPool>
{
    public Monster objectPrefab;
    public int poolSize = 50;

    private Queue<Monster> objectPool = new Queue<Monster>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Monster obj = Instantiate(objectPrefab,this.transform);
            obj.gameObject.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public Monster GetObject()
    {
        if (objectPool.Count > 0)
        {
            Monster obj = objectPool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Monster obj = Instantiate(objectPrefab);
            return obj;
        }
    }

    public void ReturnObject(Monster obj)
    {
        obj.gameObject.SetActive(false);
        objectPool.Enqueue(obj);
    }
}