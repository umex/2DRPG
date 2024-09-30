using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { get; private set; }

    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = .2f;

    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;
    public float swordReturnImpact;


    [Header("Dash info")]
    public float dashSpeed;
    public float dashDuration;
    private float defaultDashSpeed;
    public float dashDir { get; private set; }

    public SkillManager skill { get; private set; }
    public GameObject sword { get; private set; }



    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttack { get; private set; }
    public PlayerAimSwordState aimSowrd { get; private set; }
    public PlayerCatchSwordState catchSword { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        aimSowrd = new PlayerAimSwordState(this, stateMachine, "AimSword");
        catchSword = new PlayerCatchSwordState(this, stateMachine, "CatchSword");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        stateMachine.Initialize(idleState);
        skill = SkillManager.instance;
    }

    protected override void Update()
    {

        base.Update();
        // this breaks our state pattern but we need it so we can use it in all situations
        CheckForDashInput();
        stateMachine.currentState.UpdateState();

        Debug.Log("Is wall detected: " + IsWallDetected());
    }
    public void AssignNewSword(GameObject _newSword)
    {
        sword = _newSword;
    }

    public void CatchTheSword()
    {
        stateMachine.ChangeState(catchSword);
        Destroy(sword);
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();





    #region Dash
    private void CheckForDashInput()
    {

        // whenever we detect a wall we wont be able to dash
        if (IsWallDetected())
            return;

        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill())
        {
            //we want to get the user direction when it happens and use that as a dash direction
            //we might want to dash in the other way than the one we are facing
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
            {
                // if somebody uses dash while not providing any directional input
                dashDir = facingDir;
            }

            // this breaks our state pattern but we need it so we can use it in all situations
            stateMachine.ChangeState(dashState);
        }
    }
    #endregion

}
