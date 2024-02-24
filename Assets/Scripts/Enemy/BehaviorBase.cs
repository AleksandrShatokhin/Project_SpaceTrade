using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorBase : MonoBehaviour
{
    public abstract void Enter();
    public abstract void Exit();
}

public class StateHandler
{
    public BehaviorBase CurrentState { get; private set; }

    public void Initialize(BehaviorBase state)
    {
        CurrentState = state;
        state.Enter();
    }

    public void ChangeState(BehaviorBase state)
    {
        CurrentState.Exit();

        CurrentState = state;
        state.Enter();
    }
}