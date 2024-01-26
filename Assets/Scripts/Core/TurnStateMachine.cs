using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class TurnStateMachine
    {
        public TurnType Turn { get; private set; } = TurnType.Player;

        public void ChangeTurn()
        {
            switch (Turn)
            {
                case TurnType.Player:
                    Turn = TurnType.Enemy;
                    break;
                case TurnType.Enemy:
                    Turn = TurnType.Player;
                    break;
            }
        }
    }
}
