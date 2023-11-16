using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : SingletonBehaviour<InGameManager>
{
    #region State

    private Coroutine stateCoroutine;
    private GameState currentState;
    public GameStateManager StateManager = new GameStateManager();

    #endregion

    #region Facade
    
    public LandSystem LandSystem;
    public InventorySystem InventorySystem;
    public EquipmentCraftingSystem EquipmentCraftingSystem;
    public BattleSystem BattleSystem;
    public UI_Currency Currency;
    
    #endregion
    
    public void SetState<T>() where T : GameState
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = StateManager.GetState<T>();
        currentState.Enter();
        
        if (stateCoroutine != null)
        {
            StopCoroutine(stateCoroutine);
        }

        stateCoroutine = StartCoroutine(currentState.Execute());
    }

    public void HandleLandStart()
    {
        LandSystem.ShowUI();
        Currency.SetUI(Enum_Currency.LandGold);
    }

    public void HandleRewardStart()
    {
        LandSystem.CalculateLand();
        Currency.SetUI(Enum_Currency.LandGold);
    }

    public void HandleCraftStart()
    {
        EquipmentCraftingSystem.ShowUI();
        InventorySystem.ShowUI();
        Currency.SetUI(Enum_Currency.LandGold);
    }

    public void HandleBattleStart()
    {
        BattleSystem.ShowUI();
        Currency.SetUI(Enum_Currency.LandGold,Enum_Currency.MonsterKill);
    }
}
