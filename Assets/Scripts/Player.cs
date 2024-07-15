using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion

    protected void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    protected  void Start()
    {
        anim = GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
    }

    protected void Update()
    {
        stateMachine.currentState.Update();
    }

}
