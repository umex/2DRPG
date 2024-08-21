using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move info")]
    public float moveSpeed = 1.5f;
    public float idleTime = 2;


    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.UpdateState();

        //Debug.Log(IsPlayerDetected().collider.gameObject.name);
    }

    public virtual RaycastHit2D IsPlayerDetected()
    {
        RaycastHit2D playerDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

        return playerDetected;
    }
}
