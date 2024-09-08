﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Entity : MonoBehaviour
    {


        [Header("Collision info")]
        public Transform attackCheck;
        public float attackCheckRadius = 1.2f;
        [SerializeField] protected Transform groundCheck;
        [SerializeField] protected float groundCheckDistance = 1;
        [SerializeField] protected Transform wallCheck;
        [SerializeField] protected float wallCheckDistance = .8f;
        [SerializeField] protected LayerMask whatIsGround;

        public int facingDir { get; private set; } = 1;
        protected bool facingRight = true;

        #region Components
        public  Animator anim { get; private set; }
        public Rigidbody2D rb { get; private set; }
        #endregion

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {

        }

        #region Collision
        public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
            Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
        }
        #endregion

        public virtual void Damage() {
            Debug.Log(gameObject.name + " was damaged!");
        }


        #region Flip
        public virtual void Flip()
        {
            facingDir = facingDir * -1;
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);

        }

        public void FlipController(float _x)
        {
            if (_x > 0 && !facingRight)
            {
                Flip();
            }

            else if (_x < 0 && facingRight)
            {
                Flip();
            }

        }
        #endregion

        #region Velocity
        public void SetZeroVelocity() => rb.velocity = new Vector2(0, 0);

        public void SetVelocity(float _xVelocity, float _yVelocity)
        {
            rb.velocity = new Vector2(_xVelocity, _yVelocity);
            FlipController(_xVelocity);

        }

        #endregion
    }
}
