using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonBehaviour<SpawnManager>
{
    public Transform[] spawnPoints;
    
    void SpawnMonster()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject monster = MonsterPool.Instance.GetObject();
        monster.transform.position = spawnPoints[spawnIndex].position;
    }
}
