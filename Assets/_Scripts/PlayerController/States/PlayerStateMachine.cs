using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    PlayerControl player;
    StateNode currentState;

    public PlayerStateMachine(PlayerControl player)
    {
        this.player = player;
        currentState = player.stateStorage["Idle"];
        currentState.player = player;
    }

    public void Initialize()
    {
        currentState.Enter();
    }

    public void TransitionTo(StateNode nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.player = player;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState?.Execute();
    }
}
