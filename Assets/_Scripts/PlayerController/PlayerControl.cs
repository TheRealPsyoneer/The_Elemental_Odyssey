using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public PlayerStats stats;
    public List<StateNode> states;

    public Vector2 moveInput { get; private set; }
    public bool pressAttack {  get; set; }
    public Rigidbody2D rb { get; private set; }
    public Animator animator {get; private set;}

    public Dictionary<string, StateNode> stateStorage;
    public PlayerStateMachine stateMachine;

    void Awake()
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

    void Start()
    {
        stateMachine.Initialize();
    }

    void Update()
    {
        stateMachine.Execute();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        pressAttack = true;
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        pressAttack = false;
    }
}