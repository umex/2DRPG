using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);
        player.FlipController(xInput);


        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
