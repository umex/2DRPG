using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EnemyStateMachine stateMachine { get; private set; }

    protected void Awake()
    {
        stateMachine = new EnemyStateMachine();

    }

    void Update()
    {
        stateMachine.currentState.UpdateState();
    }
}
