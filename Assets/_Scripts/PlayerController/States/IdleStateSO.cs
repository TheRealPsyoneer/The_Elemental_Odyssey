using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Idle SO", fileName = "Idle")]
public class IdleStateSO : StateNode
{
    public override void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public override void Execute()
    {
        if (player.moveInput.y != 0)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Walk Vertical"]);
        }

        if (player.moveInput.x != 0)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Walk Horizontal"]);
        }

        if (player.pressAttack)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Attack"]);
        }
    }

    public override void Exit()
    {

    }
}
