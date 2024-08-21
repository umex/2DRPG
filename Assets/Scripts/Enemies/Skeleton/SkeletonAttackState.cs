namespace Assets.Scripts.Enemies.Skeleton
{
    public class SkeletonAttackState : EnemyState
    {
        private Skeleton enemy;
        public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
        {
            this.enemy = _enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            enemy.SetZeroVelocity();

            if (triggerCalled)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }

        public override void Exit()
        {
            base.Exit();

        }
    }
}
