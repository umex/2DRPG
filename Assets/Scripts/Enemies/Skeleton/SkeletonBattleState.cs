using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies.Skeleton
{
    public class SkeletonBattleState : EnemyState
    {
        private Skeleton enemy;
        protected Transform player;
        private int moveDir;

        public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            player = GameObject.Find("Player").transform;
        }

        public override void UpdateState()
        {
            base.UpdateState();

            if (enemy.IsPlayerDetected()) {
                if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }


            // changing movement driection based on player position
            if (player.position.x > enemy.transform.position.x)
            {
                moveDir = 1;
            }
            else if (player.position.x < enemy.transform.position.x) { 
                moveDir = -1;
            }

            //move skeleton 
            enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }


    }
}
