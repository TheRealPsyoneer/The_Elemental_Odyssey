using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Idle SO", fileName = "Idle")]
public class IdleStateSO : StateNode
{
    Player player;
    float enterTime;
    public override void Enter()
    {
        player = (Player) unit;
        enterTime = Time.time;
    }

    public override void Execute()
    {
        if (player.moveInput.x != 0)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Walk Horizontal"]);
        }

        if (player.moveInput.y != 0)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Walk Vertical"]);
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
