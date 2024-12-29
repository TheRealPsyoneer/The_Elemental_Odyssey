using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Walk Vertical SO", fileName = "Walk Vertical")]
public class WalkVerticalStateSO : StateNode
{
    public override void Enter()
    {
        if (player.moveInput.y > 0)
        {
            player.animator.SetBool("IsWalkingUp", true);
        }
        else
        {
            player.animator.SetBool("IsWalkingDown", true);
        }
    }

    public override void Execute()
    {
        player.rb.velocity = (Vector2.up + Vector2.right) * player.moveInput * player.stats.walkSpeed;

        if (player.moveInput.y == 0)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Idle"]);
        }

        if (player.pressAttack)
        {
            player.rb.velocity = Vector2.zero;
            player.stateMachine.TransitionTo(player.stateStorage["Attack"]);
        }
    }

    public override void Exit()
    {
        player.animator.SetBool("IsWalkingUp", false);
        player.animator.SetBool("IsWalkingDown", false);
    }
}
