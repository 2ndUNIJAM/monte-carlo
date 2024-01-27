using MonteCarlo.Data;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class TurnStateMachine
    {
        public TurnType Turn { get; private set; } = TurnType.Player;

        public ActionResult Result { get; private set; }

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
                    if (Result.IsSuccess)
                        Turn = TurnType.PlayerActionResult;
                    else
                    {
                        Turn = TurnType.Enemy;
                        Clear();
                    }
                    break;
                case TurnType.PlayerActionResult:
                    {
                        Turn = TurnType.Enemy;
                        Clear();
                    }
                    break;
                case TurnType.EnemyRandomRoll:
                    if (Result.IsSuccess)
                        Turn = TurnType.EnemyActionResult;
                    else
                    {
                        Turn = TurnType.Player;
                        Clear();
                    }
                    break;
                case TurnType.EnemyActionResult:
                    {
                        Turn = TurnType.Player;
                        Clear();
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
                    Result = result;
                    Turn = TurnType.PlayerRandomRoll;
                    break;
                case TurnType.Enemy:
                    Result = result;
                    Turn = TurnType.EnemyRandomRoll;
                    break;
                default:
                    Debug.LogWarning($"Unexpected turn change {Turn}");
                    break;
            }
        }

        private void Clear()
        {
            Result = DefaultResult;
        }
    }
}
