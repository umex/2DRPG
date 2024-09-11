using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (!player.IsGroundDetected()) 
        {
            stateMachine.ChangeState(player.airState);
        }

        // to just press and hold it use Input.GetKey()
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            stateMachine.ChangeState(player.primaryAttack);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) 
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            stateMachine.ChangeState(player.counterAttack);
        }

    }
}
