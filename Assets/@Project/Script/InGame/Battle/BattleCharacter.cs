using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : SingletonBehaviour<BattleCharacter>
{
    public Stat Stat = new Stat();
    public readonly CharacterAction ActionEvent = new CharacterAction();
    public List<Monster> Target;
    public float currentHealth;
    public bool IsAlive;
    public void Initialize()
    {
        CalculateStat();
        currentHealth = Stat[Enum_StatType.Health];
        IsAlive = true;
    }

    public void CalculateStat()
    {
        
    }
    
    public void TakeDamage(Damage damage)
    {
        currentHealth -= damage.Value;

        if (currentHealth <= 0)
        {
            IsAlive = false;
            OnDeath();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            var monster = other.GetComponent<Monster>();
            Target.Add(monster);
        }
    }

    public Monster GetCloseMonster()
    {
        if (Target.Count == 0)
        {
            return null;
        }
        
        var minDisatnace = float.MaxValue;
        Monster closeTarget = Target[0];
        var pos = transform.position;
        
        foreach (var target in Target)
        {
            var distance = Vector2.Distance(pos, target.transform.position);
            if (minDisatnace > distance)
            {
                minDisatnace = distance;
                closeTarget = target;
            }
        }

        return closeTarget;
    }

    public void Attack()
    {
        OnAttack();
    }

    public Damage GetDamage()
    {
        Damage damage = new Damage();
        
        damage.Value = Stat[Enum_StatType.Damage];
        
        if (UtilCode.GetChance(Stat[Enum_StatType.CriticalChance]))
        {
            damage.Value *= 1 + Stat[Enum_StatType.CiritcalDamage];
            OnCriticalAttack();
        }

        return damage;
    }
    
    #region Action
    public void OnTakeHit()
    {
        ActionEvent.TakeHit.Action();
    }
    
    public void OnAttack()
    {
        ActionEvent.Attack.Action();
    }
    
    public void OnCriticalAttack()
    {
        ActionEvent.Attack.Action();
    }

    public void OnDeath()
    {
        ActionEvent.Death.Action();
    }

    public void OnKill()
    {
        ActionEvent.Kill.Action();
    }
    #endregion
}
