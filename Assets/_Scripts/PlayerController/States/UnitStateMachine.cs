using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine
{
    UnitControl unit;
    StateNode currentState;

    public UnitStateMachine(UnitControl unit)
    {
        this.unit = unit;
    }

    public void Initialize()
    {
        currentState = unit.stateStorage["Idle"];
        currentState.unit = unit;
        currentState.Enter();
    }

    public void TransitionTo(StateNode nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.unit = unit;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState?.Execute();
    }
}
