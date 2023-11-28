
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : EquipmentHandler
{
    public override void Initialize()
    {
        
    }

    public override void InitEquipment(BattleCharacter player)
    {
        
    }

    public override void Hide()
    {
        
    }

    public override void OnUpdate(float dt)
    {
        
    }

    protected override void RefreshCoolDown(float dt)
    {
        
    }

    public override void ResetCoolDown()
    {
        
    }

    public void Attack()
    {
        var damage = _player.GetDamage();
        
        
    }
    
    public override void OnDeath(){}
    public override void OnHit(){}
    public override void OnKill(){}
    public override void OnAttack(){}
    public override void OnCriticalAttack(){}
    
    
}
