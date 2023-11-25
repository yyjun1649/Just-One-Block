using System;
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
    public CurrencySystem CurrencySystem;

    private PlaySystem[] _systems;
    
    #endregion

    private void Start()
    {
        _systems = GetComponents<PlaySystem>();

        foreach (var system in _systems)
        {
            system.Initialize();
        }
        
        foreach (var system in _systems)
        {
            system.LateInitialize();
        }
        
        HandleLandStart();
    }

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
        CurrencySystem.SetUI(Enum_Currency.Gold);
        LandSystem.ShowUI();
        
        SetState<GameStateLand>();
    }

    public void HandleRewardStart()
    {
        CurrencySystem.SetUI(Enum_Currency.Gold);
        LandSystem.CalculateLand();
        
        SetState<GameStateReward>();
    }

    public void HandleCraftStart()
    {
        CurrencySystem.SetUI(Enum_Currency.Gold);
        EquipmentCraftingSystem.ShowUI();
        InventorySystem.ShowUI();
        
        SetState<GameStateCraft>();
    }

    public void HandleBattleStart()
    {
        CurrencySystem.SetUI(Enum_Currency.Gold,Enum_Currency.Blood);
        BattleSystem.ShowUI();
        
        SetState<GameStateBattle>();
    }

    public bool IsEnoughCurrency(Enum_Currency currency, int count)
    {
        if (CurrencySystem.IsEnough(currency, count))
        {
            return true;
        }

        return false;
    }

    public bool ConsumeCurrency(Enum_Currency currency, int count)
    {
        if (CurrencySystem.TryConsume(currency, count))
        {
            return true;
        }

        return false;
    }
}
