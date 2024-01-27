using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class TurnStateMachine
    {
        public TurnType Turn { get; private set; } = TurnType.Enemy;

        public ActionResult PlayerResult { get; private set; }
        public ActionResult EnemyResult { get; private set; }

        public static readonly ActionResult DefaultResult = new()
        {
            IsSuccess = false,
            Target = CharacterType.None,
            Result = ResultType.None,
            Value = 0,
        };

        public void NextTurn()
        {
            switch (Turn)
            {
                case TurnType.PlayerRandomRoll:
                    Turn = TurnType.PlayerActionResult;
                    break;
                case TurnType.PlayerActionResult:
                    {
                        Turn = TurnType.EnemyRandomRoll;
                        PlayerClear();
                    }
                    break;
                case TurnType.EnemyRandomRoll:
                    if (EnemyResult.IsSuccess)
                    {
                        Turn = TurnType.EnemyActionResult;
                    }
                    else
                    {
                        Turn = TurnType.Enemy;
                        EnemyClear();
                    }

                    break;
                case TurnType.EnemyActionResult:
                    {
                        Turn = TurnType.Enemy;
                        EnemyClear();
                    }

                    break;
                default:
                    Debug.LogWarning($"Unexpected turn change {Turn}");
                    break;
            }
        }

        public void ApplyResult(ActionResult result)
        {
            switch (Turn)
            {
                case TurnType.Player:
                    PlayerResult = result;
                    Turn = TurnType.PlayerRandomRoll;
                    break;
                case TurnType.Enemy:
                    EnemyResult = result;
                    Turn = TurnType.Player;
                    break;
                default:
                    Debug.LogWarning($"Unexpected turn change {Turn}");
                    break;
            }
        }

        private void PlayerClear()
        {
            PlayerResult = DefaultResult;
        }
        private void EnemyClear()
        {
            EnemyResult = DefaultResult;
        }
    }
}
