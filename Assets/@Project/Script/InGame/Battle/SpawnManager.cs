using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : SingletonBehaviour<SpawnManager>
{
    public float radius = 5f;
    public Vector2 center = new Vector2(0, 0);
    private Vector2 randomPoint = new Vector2();

    private WaitForSeconds wfs = new WaitForSeconds(1f);
    public bool IsSpawning = true;
    
    
    public void StartWave(int count)
    {
        IsSpawning = true;
        StartCoroutine(CoSpawn(count));
    }

    public IEnumerator CoSpawn(int count)
    {
        while (count > 0)
        {
            SpawnMonster();
            count--;
            yield return wfs;
        }

        IsSpawning = false;
    }
    
    void GetRandomPointOnCircle(ref Vector2 point, Vector2 center, float radius)
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        point.x = center.x + radius * Mathf.Cos(angle);
        point.y = center.y + radius * Mathf.Sin(angle);
    }
    
    void SpawnMonster()
    {
        GetRandomPointOnCircle(ref randomPoint, center, radius);
        
        Monster monster = MonsterPool.Instance.GetObject();
        monster.transform.position = randomPoint;
        monster.Init(0);
        
        // List<SpecMonster> monsters = ListPool<SpecMonster>.Get();
        //
        // var level = InGameManager.Instance.Level;
        // foreach (var ms in SpecDataManager.Instance.SpecMonsterData)
        // {
        //     if (level == monster.Spec.level)
        //     {
        //         monsters.Add(ms);
        //     }
        // }
        //
        // var randomIndex = Random.Range(0, monsters.Count);
        //
        // monster.Init(monsters[randomIndex].fieldID);
        //
        // ListPool<SpecMonster>.Release(monsters);
    }
}
