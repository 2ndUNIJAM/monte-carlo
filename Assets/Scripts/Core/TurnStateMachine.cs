using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class TurnStateMachine
    {
        public TurnType Turn { get; private set; } = TurnType.Player;

        public void NextTurn()
        {
            switch (Turn)
            {
                case TurnType.Player:
                    Turn = TurnType.PlayerRandomRoll;
                    break;
                case TurnType.PlayerRandomRoll:
                    Turn = TurnType.PlayerActionResult;
                    break;
                case TurnType.PlayerActionResult:
                    Turn = TurnType.Enemy;
                    break;
                case TurnType.Enemy:
                    Turn = TurnType.EnemyRandomRoll;
                    break;
                case TurnType.EnemyRandomRoll:
                    Turn = TurnType.EnemyActionResult;
                    break;
                case TurnType.EnemyActionResult:
                    Turn = TurnType.Player;
                    break;
            }
        }
    }
}
