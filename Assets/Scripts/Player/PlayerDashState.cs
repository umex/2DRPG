using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        SkillManager.instance.clone.CreateClone(player.transform, new Vector3(0, 0, 0));
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);

    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!player.IsGroundDetected() && player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);



        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
