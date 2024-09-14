using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies.Skeleton
{
    public class SkeletonGroundedState : EnemyState
    {
        protected Skeleton enemy;
        protected Transform player;

        public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();
            //bad for optimization - takes all the obejects in the systems and searches trough them
            //player = GameObject.Find("Player").transform;
            player = PlayerManager.instance.player.transform;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void UpdateState()
        {
            base.UpdateState();

            // changes to aggro state if player is seen or too close behind the enemy
            if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.agroDistance)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }

    }
}
