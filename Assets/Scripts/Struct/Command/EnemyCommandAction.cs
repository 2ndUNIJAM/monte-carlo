using MonteCarlo.Data;

namespace MonteCarlo.Struct.Command
{
    public class EnemyCommandAction : IEnemyCommand
    {
        public readonly EnemyActionType ActionType;

        public EnemyCommandAction(EnemyActionType actionType)
        {
            ActionType = actionType;
        }
    }
}
