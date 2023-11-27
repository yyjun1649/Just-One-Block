using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : SingletonBehaviour<BattleCharacter>
{
    public Stat Stat = new Stat();
    public readonly CharacterAction ActionEvent = new CharacterAction();
    public List<Monster> Target;
    public float currentHealth;
    Damage damage = new Damage();
    
    public void Initialize()
    {
        CalculateStat();

        currentHealth = Stat[Enum_StatType.Health];
    }

    public void CalculateStat()
    {
        
    }
    
    public void TakeDamage()
    {
        currentHealth -= damage.Value;

        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public Monster GetCloseMonster()
    {
        return Target[0];
    }

    public void Attack()
    {
        damage.Clear();
        
        var target = GetCloseMonster();

        damage.Value = Stat[Enum_StatType.Damage];
        
        if (UtilCode.GetChance(Stat[Enum_StatType.CriticalChance]))
        {
            damage.Value *= 1 + Stat[Enum_StatType.CiritcalDamage];
            OnCriticalAttack();
        }

        target.TakeDamage(damage);
        OnAttack();

        if (!target.isAlive)
        {
            OnKill();
        }
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
