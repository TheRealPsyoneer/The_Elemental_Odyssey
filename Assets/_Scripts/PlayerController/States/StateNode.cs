using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateNode : ScriptableObject
{
    [HideInInspector]
    public PlayerControl player;
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
