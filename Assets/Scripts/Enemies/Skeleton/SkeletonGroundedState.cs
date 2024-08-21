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

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void UpdateState()
        {
            base.UpdateState();

            if (enemy.IsPlayerDetected())
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }

    }
}
