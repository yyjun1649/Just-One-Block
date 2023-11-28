using UnityEngine;

public abstract class EquipmentHandler
{
    [SerializeField] protected Transform _skillParent;
    protected BattleCharacter _player;
    protected bool _isInitialized;

    public abstract void Initialize();
    public abstract void InitEquipment(BattleCharacter player);
    
    public abstract void Hide();
    
    public abstract void OnUpdate(float dt);
    protected abstract void RefreshCoolDown(float dt);
    public abstract void ResetCoolDown();
    
    
    public virtual void OnDeath(){}
    public virtual void OnHit(){}
    public virtual void OnKill(){}
    public virtual void OnHoverAttack(){}
    public virtual void OnAttack(){}
    public virtual void OnCriticalAttack(){}
}