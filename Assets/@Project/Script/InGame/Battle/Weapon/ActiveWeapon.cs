
using System.Collections;
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
        var targets = _player.GetCloseMonster();

        SetPrjectilePosition();

        Attack(targets);
        OnAttack();

        yield return new WaitForSeconds(0.3f);
    }

    protected virtual void SetPrjectilePosition()
    {
        transform.position = _player.transform.position;
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

    protected virtual void Attack(Monster target)
    {
        if (target == null || !target.isAlive)
        {
            return;
        }

        var projectile = ProjectilePool.Instance.GetProjectile();
        
        projectile
            .SetPos(_player.transform.position)
            .SetDir(GetPrjectileDirection(target))
            .SetAction(_player.ActionEvent.OnTargetHit.Action)
            .Initialize(_specData.projectileID);
        
        projectile.Shot();
    }

    protected virtual void OnAttack()
    {
        _player.ActionEvent.Attack.Action();
    }
}
