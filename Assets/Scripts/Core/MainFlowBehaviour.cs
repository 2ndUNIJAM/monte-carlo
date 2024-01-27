using System.Collections.Generic;
using MonteCarlo.Data;
using MonteCarlo.Enemy;
using MonteCarlo.Player;
using MonteCarlo.Struct.Command;
using UnityEngine;

namespace MonteCarlo.Core
{
    public class MainFlowBehaviour : SingletonBehaviour<MainFlowBehaviour>
    {
        public TurnType Turn => turn.Turn;
        public float PlayerHpRatio => player.HpRatio;
        public float EnemyHpRatio => enemy.HpRatio;
        public int PlayerHp => player.Hp;


        private TurnStateMachine turn;
        private PlayerBase player;
        private EnemyBase enemy;
        private RevolverToy revolverToy;

        private readonly List<ICommand> commands = new();

        void Awake()
        {
            turn = new TurnStateMachine();
            player = new PlayerBase(BattleDataHolder.Instance.Player);
            enemy = new EnemyBase(BattleDataHolder.Instance.Enemy);
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

        public int getPlayerAttackDamage()
        {
            return player.AttackInfo.Damage;
        }
        public float getPlayerAttackProbability()
        {
            return player.AttackInfo.Probability;
        }
        public int getPlayerDefenceAmount()
        {
            return player.DefenceInfo.DefenceAmount;
        }
        public float getPlayerDefenceProbability()
        {
            return player.DefenceInfo.Probability;
        }

        public int getPlayerHealAmount()
        {
            return player.HealInfo.HealAmount;
        }
        public float getPlayerHealProbability()
        {
            return player.HealInfo.Probability;
        }


        private void PlayerTurn(ICommand command)
        {
            switch (command)
            {
                case PlayerCommandTurnEnd:
                    turn.ApplyResult(false, 0);
                    break;
                case PlayerCommandAttack:
                    var (isSucceed, damage) = player.AttackAction();
                    Debug.Log("공격 성공?" + isSucceed);
                    Debug.Log(damage + " 로 공격 성공");
                    enemy.DecreaseHp(damage);
                    break;
                case PlayerCommandDefence:
                    player.addDefence(5);
                    Debug.Log("방어도 획득");
                    break;
                case PlayerCommandHeal:
                    player.healHP();
                    Debug.Log(player.Hp + "만큼 힐 성공");
                    break;
                default:
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
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
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
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
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
                    break;
            }

        }

        private void EnemyTurn(ICommand command)
        {
            switch (command)
            {
                case EnemyCommandTurnEnd:
                    turn.ApplyResult(false, 0);
                    break;
                case RevolverGunCommandTurnEnd:
                    if (turn.Turn is TurnType.Enemy)
                        player.DecreaseHp(revolverToy.revolverAttack());
                    break;
                default:
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
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
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
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
                    Debug.LogWarning($"Turn-Command mismatch - Turn: {Turn} / Command: {command}");
                    break;
            }
        }

        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
        }
    }
}
