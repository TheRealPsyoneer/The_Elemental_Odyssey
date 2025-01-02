using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
    [SerializeField] AttackStats stats;
    public Stack<AttackBehaviour> pool;

    public abstract void Behaviour();
}
