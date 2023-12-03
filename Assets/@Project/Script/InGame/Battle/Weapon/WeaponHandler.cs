using System.Collections.Generic;
using System.Linq;

public class WeaponHandler : EquipmentHandler
{
    private List<Weapon> _weaponList = new List<Weapon>();
    
    private List<ActiveWeapon> _activeWeaponList = new List<ActiveWeapon>();
    private List<PassiveWeapon> _passiveWeaponList = new List<PassiveWeapon>();
    private List<Weapon> _equippedWeaponList = new List<Weapon>();
    
    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        if (_isInitialized)
        {
            return;
        }

        _isInitialized = true;
        
        _weaponList = new List<Weapon>(_trParent.childCount);
        _weaponList = _trParent.GetComponentsInChildren<Weapon>().ToList();
    }

    public override void InitEquipment()
    {
        var skillSpecDatas = SpecDataManager.Instance.SpecWeaponData;

        for (var i = 0; i < _weaponList.Count; i++)
        {
            _weaponList[i].Initialize(skillSpecDatas[i]);
            _weaponList[i].gameObject.SetActive(false);
        }
    }
    
    public override void Hide()
    {

    }

    public override void OnUpdate(float dt)
    {
        RefreshCoolDown(dt);
    }
    
    protected override void RefreshCoolDown(float dt)
    {
        foreach (var active in _activeWeaponList)
        {
            if (active == null)
            {
                continue;
            }

            active.UpdateCoolTime(dt);
        }

        foreach (var passive in _passiveWeaponList)
        {
            if (passive == null)
            {
                continue;
            }

            passive.UpdateCoolTime(dt);
        }
    }

    public override void ResetCoolDown()
    {
        foreach (var active in _activeWeaponList)
        {
            if (active == null)
            {
                continue;
            }

            active.ResetSkill();
        }
        
        foreach (var passive in _passiveWeaponList)
        {
            if (passive == null)
            {
                continue;
            }

            passive.ResetSkill();
        }
    }

    public virtual void ForceUse(int skillIndex)
    {
        _weaponList[skillIndex].ForceAttack();
    }

    public void EquipWeapon(SpecWeapon weapon)
    {
        if (weapon == null)
        {
            return;
        }
        
        _weaponList[weapon.fieldID].Initialize(weapon);
        
        _equippedWeaponList.Add(_weaponList[weapon.fieldID]);
    }
    
    public void TryUseAutoSkill(bool isEnemy = false)
    {
        if (_player.GetCloseMonster() == null)
        {
            return;
        }
            
        for (var i = 0; i < _equippedWeaponList.Count; i++)
        {
            var weapon = _equippedWeaponList[i];
                
            if (weapon != null && weapon.TryAttack())
            {
                break;
            }
        }
    }


    public override void OnAttack()
    {
        foreach (var weapon in _weaponList)
        {
            if (weapon != null)
            {
                weapon.OnAttack();
            }
        }
    }

    public override void OnDeath()
    {
        foreach (var weapon in _weaponList)
        {
            if (weapon != null)
            {
                weapon.OnDeath();
            }
        }
    }

    public override void OnKill()
    {
        foreach (var weapon in _weaponList)
        {
            if (weapon != null)
            {
                weapon.OnKill();
            }
        }
    }

    public override void OnCriticalAttack()
    {
        foreach (var weapon in _weaponList)
        {
            if (weapon != null)
            {
                weapon.OnCriticalAttack();
            }
        }
    }

    public override void OnHit()
    {
        foreach (var weapon in _weaponList)
        {
            if (weapon != null)
            {
                weapon.OnHit();
            }
        }
    }
}
