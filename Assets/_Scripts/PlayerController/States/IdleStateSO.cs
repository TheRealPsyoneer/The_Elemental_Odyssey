using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Idle SO", fileName = "Idle")]
public class IdleStateSO : StateNode
{
    float enterTime;
    public override void Enter()
    {
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

        //if (Time.time - enterTime > player.stats.attackComboWaitTime)
        //{
        //    player.animator.SetInteger("AttackOrder", 1);
        //}
    }

    public override void Exit()
    {

    }
}
