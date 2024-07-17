using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void UpdateState()
    {
        base.UpdateState();

        // player not running if standing in fron of tha wall
        if (xInput == player.facingDir && player.IsWallDetected())
        {
            return;
        }

        if (xInput != 0) 
        { 
            stateMachine.ChangeState(player.moveState);
        }
    }
}
