
using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : SingletonBehaviour<EquipmentManager>, GameEventListener<RefreshEvent>
{
    [SerializeField] protected WeaponHandler _weaponHandler;

    private List<EquipmentHandler> _equipmentHandlers;

    private BattleCharacter _player;
    private bool _isOwnerInited;
    private bool _isHandlerInited;

    protected override void Awake()
    {
        base.Awake();
        
        Initialize(BattleCharacter.Instance);

        RefreshSkill();
        
        this.AddGameEventListening<RefreshEvent>();
    }

    protected virtual void Update()
    {
        if (!_isOwnerInited || InGameManager.Instance._currentState != Enum_State.Battle)
        {
            return;
        }

        if (!_player.IsAlive)
        {
            return;
        }
        
        var deltaTime = Time.deltaTime;
        
        HandlerAction((handler) => { handler.OnUpdate(deltaTime); });

        OnUpdate();
    }
    
    protected virtual void OnUpdate() { }
    
    public void RefreshSkill()
    {
        
    }
    
    public void Initialize(BattleCharacter player)
    {
        _player = player;
        _isOwnerInited = true;
        
        HandlerAction((handler) => { handler.Initialize(); });
        
        InitSkill();
        InitTrigger();
    }
    
    private void HandlerAction(Action<EquipmentHandler> action)
    {
        if (!_isHandlerInited)
        {
            _equipmentHandlers = new List<EquipmentHandler>()
            {
                _weaponHandler,
            };

            _isHandlerInited = true;
        }
        
        foreach (var skillHandler in _equipmentHandlers)
        {
            action(skillHandler);
        }
    }

    public void Clear()
    {
        _player = null;
        _isOwnerInited = false;
    }

    private void InitTrigger()
    {
        var actionEvent = _player.ActionEvent;
        
        actionEvent.Attack.AddListener(OnAttack);
        actionEvent.CriticalAttack.AddListener(OnCriticalAttack);
        actionEvent.Death.AddListener(OnDeath);
        actionEvent.TakeHit.AddListener(OnHit);
        actionEvent.Kill.AddListener(OnKill);
        actionEvent.OnTargetHit.AddListener(OnTargetHit);
    }

    private void InitSkill()
    {
        HandlerAction((handler) => { handler.InitEquipment(); });
    }
    
    public void HideSkills()
    {
        HandlerAction((handler) => { handler.Hide(); });
    }
    
    public void ForceUse(int skillIndex)
    {
        _weaponHandler.ForceUse(skillIndex);
    }

    // private void InitWeapon()
    // {
    //     var activeIndex = PlayerDataManager.Instance.GetEquippedSkill(false);
    //     var passiveIndex = PlayerDataManager.Instance.GetEquippedSkill(true);
    //
    //     InitBerserkSkill(activeIndex, passiveIndex);
    // }
    
    public void EquipWeapon(int weaponIndex)
    {
        var weapon = SpecDataManager.Instance.SpecWeaponData[weaponIndex];
        
        _weaponHandler.EquipWeapon(weapon);
    }

    private void OnDeath()
    {
        HandlerAction((handler) => { handler.OnDeath(); });
    }

    private void OnHit()
    {
        HandlerAction((handler) => { handler.OnHit(); });
    }

    private void OnKill()
    {
        HandlerAction((handler) => { handler.OnKill(); });
    }
    
    private void OnCriticalAttack()
    {
        HandlerAction((handler) => { handler.OnCriticalAttack(); });
    }

    private void OnAttack()
    {
        HandlerAction((handler) => { handler.OnAttack(); });
    }
    
    private void OnTargetHit()
    {
        HandlerAction((handler) => { handler.OnTargetHit(); });
    }

    public void OnGameEvent(RefreshEvent gameEventType)
    {
        if(gameEventType.Type == Enum_RefreshEventType.Weapon)
        {
            RefreshSkill();
        }
    }
}
