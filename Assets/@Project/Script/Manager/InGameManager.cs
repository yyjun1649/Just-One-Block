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
    public Enum_State _currentState;

    #endregion

    #region Facade
    
    public LandSystem LandSystem;
    public InventorySystem InventorySystem;
    public EquipmentCraftingSystem EquipmentCraftingSystem;
    public BattleSystem BattleSystem;
    public CurrencySystem CurrencySystem;

    private PlaySystem[] _systems;
    
    #endregion

    [SerializeField] private GameObject _nextButton;

    private void Start()
    {
        _systems = GetComponentsInChildren<PlaySystem>();

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

    public void TryNextHandleStart()
    {
        switch (_currentState)
        {
            case Enum_State.Land:
                HandleRewardStart();
                break;
            case Enum_State.Reward:
                HandleCraftStart();
                break;
            case Enum_State.Craft:
                HandleBattleStart();
                break;
            case Enum_State.Battle:
                HandleLandStart();
                break;
        }
    }

    public void HandleLandStart()
    {
        _currentState = Enum_State.Land;
        
        CurrencySystem.SetUI(Enum_Currency.Gold);
        LandSystem.ShowUI();
        _nextButton.SetActive(true);

        BattleSystem.ShowOffUI();
        
        SetState<GameStateLand>();
    }

    public void HandleRewardStart()
    {
        _currentState = Enum_State.Reward;
        
        CurrencySystem.SetUI(Enum_Currency.Gold);
        LandSystem.CalculateLand();
        _nextButton.SetActive(false);
        
        LandSystem.ShowOffUI();
        
        SetState<GameStateReward>();
    }

    public void HandleCraftStart()
    {
        _currentState = Enum_State.Craft;
        
        CurrencySystem.SetUI(Enum_Currency.Gold);
        EquipmentCraftingSystem.ShowUI();
        InventorySystem.ShowUI();
        _nextButton.SetActive(true);
        
        SetState<GameStateCraft>();
    }

    public void HandleBattleStart()
    {
        _currentState = Enum_State.Battle;
        
        CurrencySystem.SetUI(Enum_Currency.Gold,Enum_Currency.Blood);
        BattleSystem.ShowUI();
        _nextButton.SetActive(false);
        
        EquipmentCraftingSystem.ShowOffUI();
        InventorySystem.ShowOffUI();
        
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

    public bool TryConsumeCurrency(Enum_Currency currency, int count)
    {
        if (CurrencySystem.TryConsume(currency, count))
        {
            return true;
        }

        return false;
    }
}
