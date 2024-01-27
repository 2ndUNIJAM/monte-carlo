using System.Collections.Generic;
using MonteCarlo.Data;
using MonteCarlo.Enemy;
using MonteCarlo.Player;
using MonteCarlo.Struct;
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
        public int EnemyHp => enemy.Hp;

        private TurnStateMachine turn;
        private PlayerBase player;
        private EnemyBase enemy;

        private readonly List<ICommand> commands = new();


        void Awake()
        {
            var dataHolder = BattleDataHolder.Instance;

            turn = new TurnStateMachine();
            player = new PlayerBase(dataHolder.Player);
            enemy = new EnemyBase(dataHolder.Enemy, dataHolder.EnemyAction);
        }

        void Update()
        {
            var previousTurn= turn.Turn;
            
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
            if (turn.Turn != previousTurn) {
                switch (turn.Turn)
                {
                    case TurnType.Player:
                        break;
                    case TurnType.PlayerRandomRoll:
                        break;
                    case TurnType.PlayerActionResult:
                        break;
                    case TurnType.Enemy:
                        SoundManager.Instance.onCardClip();
                        break;
                    case TurnType.EnemyRandomRoll:
                        break;
                    case TurnType.EnemyActionResult:
                        break;
                }
            }
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
            SoundManager.Instance.onCardClip();
            switch (command)
            {
                case PlayerCommandTurnEnd:
                    turn.ApplyResult(TurnStateMachine.DefaultResult);
                    break;
                case PlayerCommandAttack:
                    {
                        var result = player.AttackAction();
                        Debug.Log($"공격 결과: {result.IsSuccess}, 데미지: {result.Value}");
                        enemy.DecreaseHp(result.Value);
                        turn.ApplyResult(result);
                        SoundManager.Instance.onCoinClip();
                        
                        break;
                    }
                case PlayerCommandDefence:
                    {
                        var result = player.ShieldUp();
                        Debug.Log($"방어 결과: {result.IsSuccess}, 실드량: {result.Value}");
                        turn.ApplyResult(result);
                        break;
                    }
                case PlayerCommandHeal:
                    {
                        var result = player.HealHP();
                        Debug.Log($"회복 결과: {result.IsSuccess}, 힐량: {result.Value}");
                        turn.ApplyResult(result);
                        break;
                    }
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
                    {
                        turn.ApplyResult(TurnStateMachine.DefaultResult);
                        break;
                    }
                case EnemyCommandAction actionCmd:
                    {
                        var result = enemy.Execute(actionCmd.ActionType);
                        Debug.Log($"행동 결과: {result.IsSuccess}, 행동 타입: {result.Result}, 값: {result.Value}");
                        turn.ApplyResult(result);
                        break;
                    }
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

                    var result = turn.EnemyResult;
                    if (result.IsSuccess)
                    {
                        if (result.Result is ResultType.GetDamage)
                            player.DecreaseHp(result.Value);
                        if (result.Result is ResultType.GetHeal)
                            enemy.IncreateHp(result.Value);
                    }
                    SoundManager.Instance.onRevolverCockClip();

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
