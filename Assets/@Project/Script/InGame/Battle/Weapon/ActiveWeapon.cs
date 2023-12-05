
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Weapon
{
    protected Coroutine WeaponCoroutine;

    public override bool TryAttack()
    {
        if (!IsSkillEnable() || InGameManager.Instance._currentState != Enum_State.Battle)
        {
            return false;
        }

        ResetCoolDownTimer();

        StopAllCoroutines();
        WeaponCoroutine = StartCoroutine(SkillDelayCoroutine());
        
        return true;
    }
    
    public override void ForceAttack()
    {
        StopAllCoroutines();
        WeaponCoroutine = StartCoroutine(SkillDelayCoroutine());

        return;
    }
    
    protected virtual IEnumerator SkillDelayCoroutine()
    {
        var target = _player.GetCloseMonster();

        for (int i = 0; i < count; i++)
        {
            var projectile = ProjectilePool.Instance.GetProjectile();

            int leftRight = i % 2 == 0 ? -1 : 1;
            int value = (i+1) / 2;
            float euler = leftRight * value * 15f;
            
            projectile
                .SetPos(_player.transform.position)
                .SetDir(GetPrjectileDirection(target))
                .SetDir2(euler)
                .SetAction(_player.ActionEvent.OnTargetHit.Action)
                .Initialize(_specData.projectileID);
            
            Attack(target,projectile);
            OnAttack();
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);
    }
    
    protected virtual Vector3 GetPrjectileDirection(Monster target)
    {
        return Vector3.Normalize(target.transform.position - _player.transform.position);
    }
    
    protected WaitForSeconds GetDelay(float duration)
    {
        var speed =  _player.Stat[Enum_StatType.AttackSpeed];
        return new WaitForSeconds(duration / speed);
    }

    protected virtual void Attack(Monster target, BaseProjectile projectile)
    {
        if (target == null || !target.isAlive)
        {
            return;
        }
        
        projectile.Shot();
    }

    protected virtual void OnAttack()
    {
        _player.ActionEvent.Attack.Action();
    }

    private const float attackCountDelay = 0.1f;
    private WaitForSeconds attckCountwfs = new WaitForSeconds(attackCountDelay);
}
