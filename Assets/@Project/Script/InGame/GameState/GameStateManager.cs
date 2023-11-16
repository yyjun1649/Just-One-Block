using System;
using System.Collections.Generic;

public class GameStateManager
{
    private Dictionary<Type, GameState> states = new Dictionary<Type, GameState>();

    public T GetState<T>() where T : GameState
    {
        Type type = typeof(T);

        if (!states.ContainsKey(type))
        {
            GameState state = (T)Activator.CreateInstance(type);
            states.Add(type, state);
        }

        return (T)states[type];
    }
}