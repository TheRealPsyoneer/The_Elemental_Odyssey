using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player States/Attack SO", fileName = "Attack")]
public class AttackStateSO : StateNode
{
    Player player;
    float initFrame;
    public override void Enter()
    {
        player = (Player) unit;
        unit.animator.SetTrigger("Attack_trig");
        initFrame = Time.time;
        player.CancelResetAttackComboTime();
        player.attackEvent.Broadcast(unit);
    }

    public override void Execute()
    {
        if (Time.time == initFrame) return;

        if (Time.time - initFrame >= unit.animator.GetCurrentAnimatorStateInfo(0).length)
        {
            player.stateMachine.TransitionTo(unit.stateStorage["Idle"]);
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
