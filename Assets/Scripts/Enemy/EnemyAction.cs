using MonteCarlo.Struct;

namespace MonteCarlo.Enemy
{
    public abstract class EnemyAction
    {
        public abstract float Probability { get; }

        public abstract ActionResult Execute();
    }
}
