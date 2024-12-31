using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Walk Horizontal SO", fileName = "Walk Horizontal")]
public class WalkHorizontalStateSO : StateNode
{
    Player player;
    public override void Enter()
    {
        player = (Player) unit;
        player.animator.SetBool("IsWalkingHorizontal", true);
        Vector2 direction = player.transform.localScale;
        if (player.moveInput.x > 0)
        {
            direction.x = Mathf.Abs(direction.x);
        }
        else
        {
            direction.x = -Mathf.Abs(direction.x);
        }
        player.transform.localScale = direction;
    }

    public override void Execute()
    {
        player.rb.velocity = (Vector2.up + Vector2.right) * player.moveInput * player.stats.walkSpeed;

        if (player.moveInput.x == 0)
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
        player.animator.SetBool("IsWalkingHorizontal", false);
    }
}
