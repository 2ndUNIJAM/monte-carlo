using MonteCarlo.Data;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class TurnStateMachine
    {
        public TurnType Turn { get; private set; } = TurnType.Player;

        public bool IsSuccess { get; private set; } = false;
        public int Value { get; private set; } = 0;

        public void NextTurn()
        {
            switch (Turn)
            {
                case TurnType.PlayerRandomRoll:
                    if (IsSuccess)
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
                    if (IsSuccess)
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
            }
        }

        public void ApplyResult(bool isSuccess, int value)
        {
            switch (Turn)
            {
                case TurnType.Player:
                    IsSuccess = isSuccess;
                    Value = value;
                    Turn = TurnType.PlayerRandomRoll;
                    break;
                case TurnType.Enemy:
                    IsSuccess = isSuccess;
                    Value = value;
                    Turn = TurnType.EnemyRandomRoll;
                    break;
                default:
                    Debug.LogWarning($"Unexpected turn change {Turn}");
                    break;
            }
        }

        private void Clear()
        {
            IsSuccess = false;
            Value = 0;
        }
    }
}
