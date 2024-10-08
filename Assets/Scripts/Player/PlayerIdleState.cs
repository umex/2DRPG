public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // so that we dont move after jump
        player.SetZeroVelocity();
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

        if (xInput != 0 && !player.isBusy)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
