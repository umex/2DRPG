using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerState  
{
    protected PlayerStateMachine stateMachine;
    protected Player player;


    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("Im entering state: " + animBoolName);
        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        Debug.Log("Im in state: " + animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("Im exiting state: " + animBoolName);
        player.anim.SetBool(animBoolName, false);
    }
}
