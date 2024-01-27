using System.Collections.Generic;
using MonteCarlo.Data;
using MonteCarlo.Enemy;
using MonteCarlo.Player;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class MainFlowBehaviour : SingletonBehaviour<MainFlowBehaviour>
    {
        public TurnType Turn => turn.Turn;
        public float PlayerHpRatio => player.HpRatio;
        public float EnemyHpRatio => enemy.HpRatio;

        private TurnStateMachine turn;
        private PlayerBase player;
        private EnemyBase enemy;
        private RevolverToy revolverToy;

        private readonly List<ICommand> commands = new();

        void Awake()
        {
            turn = new TurnStateMachine();
            player = new PlayerBase(BattleDataHolder.Instance.player?.playerHP ?? 100);
            enemy = new EnemyBase(100);
            revolverToy = new RevolverToy();
        }

        void Update()
        {
            foreach (var cmd in commands)
            {
                switch (turn.Turn)
                {
                    case TurnType.Player:
                        PlayerTurn(cmd);
                        break;
                    case TurnType.PlayerRandomRoll:
                        PlayerRandomRoll(cmd);
                        break;
                    case TurnType.PlayerActionResult:
                        PlayerActionResult(cmd);
                        break;
                    case TurnType.Enemy:
                        EnemyTurn(cmd);
                        break;
                    case TurnType.EnemyRandomRoll:
                        EnemyRandomRoll(cmd);
                        break;
                    case TurnType.EnemyActionResult:
                        EnemyActionResult(cmd);
                        break;
                }
            }
            commands.Clear();
        }

        private void PlayerTurn(ICommand command)
        {
            switch (command)
            {
                case PlayerCommandTurnEnd:
                    turn.NextTurn();
                    break;
                case PlayerCommandAttack:
                    Debug.Log(player.damage + " 로 공격 성공");
                    break;
                case PlayerCommandDefence:
                    player.addDefence(5);
                    Debug.Log("방어도 획득");
                    break;
                case PlayerCommandHeal:
                    player.healHP();
                    Debug.Log(player.hp + "만큼 힐 성공");
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }
        }

        private void PlayerRandomRoll(ICommand command)
        {
            switch (command)
            {
                case PlayerCommandRollEnd:
                    turn.NextTurn();
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }

        }

        private void PlayerActionResult(ICommand command)
        {
            switch (command)
            {
                case PlayerCommandResultEnd:
                    turn.NextTurn();
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }

        }

        private void EnemyTurn(ICommand command)
        {
            switch (command)
            {
                case EnemyCommandTurnEnd:
                    turn.NextTurn();
                    break;
                case RevolverGunCommandTurnEnd:
                    if (turn.Turn is Data.TurnType.Enemy)
                        player.decreaseHp(revolverToy.revolverAttack());
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }
        }

        private void EnemyRandomRoll(ICommand command)
        {
            switch (command)
            {
                case EnemyCommandRollEnd:
                    turn.NextTurn();
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }
        }

        private void EnemyActionResult(ICommand command)
        {
            switch (command)
            {
                case EnemyCommandResultEnd:
                    turn.NextTurn();
                    break;
                default:
                    Debug.LogWarning($"Turn-Command miss match - Turn: Player / Command: {command}");
                    break;
            }
        }

        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
        }
    }
}
