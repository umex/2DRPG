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

            if (enemy.IsPlayerDetected())
            {

                stateTimer = enemy.battleTime;

                if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
                {
                    if (CanAttack())
                    {
                        stateMachine.ChangeState(enemy.attackState);
                    }
                }
            }
            else {
                // player losses aggro after certain amount of time or distance
                if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 7) {
                    stateMachine.ChangeState(enemy.idleState);
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

        private bool CanAttack()
        {
            if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
            {
                enemy.lastTimeAttacked = Time.time;
                return true;
            }

            return false;
        }
    }
}
