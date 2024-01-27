using MonteCarlo.Struct;

namespace MonteCarlo.Enemy
{
    public abstract class EnemyAction
    {
        protected readonly EnemyAttackData attackData;
        protected EnemyAction(EnemyAttackData attackData)
        {
            this.attackData = attackData;
        }

        public abstract ActionResult Execute(int id);
    }
}
