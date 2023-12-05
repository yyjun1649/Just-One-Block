using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : SingletonBehaviour<ProjectilePool>
{
    public Projectile0 projectilePrefab;    
    public int poolSize = 20;              

    private Queue<BaseProjectile> projectiles; 

    protected override void Awake()
    {
        base.Awake();

        projectiles = new Queue<BaseProjectile>();

        for (int i = 0; i < poolSize; i++)
        {
            BaseProjectile obj = Instantiate(projectilePrefab,this.transform);
            obj.gameObject.SetActive(false);
            projectiles.Enqueue(obj);
        }
    }
    
    public BaseProjectile GetProjectile()
    {
        if (projectiles.Count > 0)
        {
            BaseProjectile projectile = projectiles.Dequeue();
            return projectile;
        }
        else
        {
            BaseProjectile newProjectile = Instantiate(projectilePrefab,this.transform);
            newProjectile.gameObject.SetActive(false);
            return newProjectile;
        }
    }

    // 투사체를 풀로 반환하는 메소드
    public void ReturnProjectile(BaseProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectiles.Enqueue(projectile);
    }
}