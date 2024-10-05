using UnityEngine;

public class PlayerBlackholeState : PlayerState
{
    private float flyTime = .25f;
    private bool skillUsed;


    private float defaultGravity;

    public PlayerBlackholeState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }



    //when skill is used player will levitate a bit and trigger the blackhole
    public override void Enter()
    {
        base.Enter();
        skillUsed = false;
        stateTimer = flyTime;
        defaultGravity = rb.gravityScale;
        rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
        player.rb.gravityScale = defaultGravity;

    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (stateTimer > 0)
        {
            rb.velocity = new Vector2(0, 15);
        }

        if (stateTimer < 0)
        {
            rb.velocity = new Vector2(0, -.1f);

            if (!skillUsed)
            {
                if (player.skill.blackhole.CanUseSkill()) { 
                    skillUsed = true;
                }
            }
        }

        if (player.skill.blackhole.SkillCompleted()) { 
            stateMachine.ChangeState(player.airState);
        }

    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}