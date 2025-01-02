using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : UnitControl
{
    public PlayerStats stats;
    public PlayerSubject attackEvent;

    public Vector2 moveInput { get; private set; }
    public bool pressAttack { get; set; }

    Coroutine resetAttackComboCoroutine;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        pressAttack = true;
        StartCoroutine(ResetPressAttack());
    }

    IEnumerator ResetPressAttack()
    {
        yield return new WaitForSeconds(stats.defaultAttackPressingTime);
        pressAttack = false;
    }

    public void StartResetAttackComboTime()
    {
        resetAttackComboCoroutine = StartCoroutine(ResetAttackCombo());
    }

    public void CancelResetAttackComboTime()
    {
        if (resetAttackComboCoroutine != null)
        {
            StopCoroutine(resetAttackComboCoroutine);
            resetAttackComboCoroutine = null;
        }
    }

    IEnumerator ResetAttackCombo()
    {
        yield return new WaitForSeconds(stats.attackComboWaitTime);
        animator.SetInteger("AttackOrder", 1);
    }
}
