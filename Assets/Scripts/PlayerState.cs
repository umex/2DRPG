using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// everything in here will be available to every state
public class PlayerState  
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;


    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        rb = player.rb; //so we can use rb directly in states instead of player.rb
        player.anim.SetBool(animBoolName, true);
    }

    public virtual void UpdateState()
    {

        stateTimer -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
        
        Debug.Log("Im in state: " + animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("Im exiting state: " + animBoolName);
        player.anim.SetBool(animBoolName, false);
    }
}
