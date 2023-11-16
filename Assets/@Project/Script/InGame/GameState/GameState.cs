using System.Collections;
using UnityEngine;

public abstract class GameState
{
    public abstract void Enter();
    public abstract IEnumerator Execute();
    public abstract void Exit();
}