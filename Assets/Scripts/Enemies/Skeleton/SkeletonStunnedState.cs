using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies.Skeleton
{
    public class SkeletonStunnedState : EnemyState
    {
        private Skeleton enemy;

        public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();

            enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);

            stateTimer = enemy.stunDuration;

            rb.velocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
        }

        public override void Exit()
        {
            base.Exit();

            enemy.fx.Invoke("CancelColorChange", 0);
        }

        public override void UpdateState()
        {
            base.UpdateState();

            if (stateTimer < 0)
                stateMachine.ChangeState(enemy.idleState);
        }
    }
}
