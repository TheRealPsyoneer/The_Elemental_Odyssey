using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitControl : MonoBehaviour
{
    public List<StateNode> states;

    public Rigidbody2D rb { get; private set; }
    public Animator animator {get; private set;}

    public Dictionary<string, StateNode> stateStorage;

    public UnitStateMachine stateMachine;
    

    protected virtual void Awake()
    {
        stateStorage = new();
        foreach (StateNode state in states)
        {
            stateStorage[state.name] = state;
        }
        stateMachine = new(this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        stateMachine.Initialize();
    }

    protected virtual void Update()
    {
        stateMachine.Execute();
    }

}
