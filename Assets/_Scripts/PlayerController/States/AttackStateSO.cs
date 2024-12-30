using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Attack SO", fileName = "Attack")]
public class AttackStateSO : StateNode
{
    float initFrame;
    public override void Enter()
    {
        player.animator.SetTrigger("Attack_trig");
        initFrame = Time.time;
        player.CancelResetAttackComboTime();
    }

    public override void Execute()
    {
        if (Time.time == initFrame) return;

        if (Time.time - initFrame >= player.animator.GetCurrentAnimatorStateInfo(0).length)
        {
            player.stateMachine.TransitionTo(player.stateStorage["Idle"]);
        }
    }

    public override void Exit()
    {
        int order = player.animator.GetInteger("AttackOrder");
        if (order < player.stats.maxCombo)
        {
            player.animator.SetInteger("AttackOrder", order + 1);
        }
        else
        {
            player.animator.SetInteger("AttackOrder", 1);
        }
        player.StartResetAttackComboTime();
    }
}
