
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected BattleCharacter _player;
    protected SpecWeapon _specData;
    
    protected float _skillCooldownTimer;
    protected float _skillCooldown;

    
    public virtual void Initialize(SpecWeapon weapon)
    {
        _player = BattleCharacter.Instance;
        _specData = weapon;
    }
    
    public virtual void OnUpdate(float dt)
    {
        
    }
    
    public bool IsSkillEnable()
    {
        return _skillCooldownTimer <= 0;
    }
    
    public void UpdateCoolTime(float deltaTime)
    {
        _skillCooldownTimer -= deltaTime;
    }

    public virtual void ForceAttack()
    {
    }

    public virtual bool TryAttack()
    {
        return false;
    }
    
    public void ResetCoolDownTimer()
    {
        _skillCooldown = GetSkillCoolDown();

        _skillCooldownTimer = _skillCooldown;
    }
    
    private float GetSkillCoolDown()
    {
        return _specData.coolDown;
    }
    
    public void ResetSkill()
    {
        ResetCoolDownTimer();
        StopAllCoroutines();
        _skillCooldownTimer = 0;
    }
    
    public virtual void OnDeath(){}
    public virtual void OnHit(){}
    public virtual void OnKill(){}
    public virtual void OnAttack(){}
    public virtual void OnCriticalAttack(){}
    
    
}
