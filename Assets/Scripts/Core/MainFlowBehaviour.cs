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

        private TurnStateMachine turn;
        private PlayerBase player;
        private EnemyBase enemy;
        private readonly List<ICommand> commands = new();

        void Awake()
        {
            turn = new TurnStateMachine();
            player = new PlayerBase(BattleDataHolder.Instance.player?.playerHP ?? 100);
            enemy = new EnemyBase(100);
        }
        public TurnType getTurn()
        {
            return turn.Turn;
        }

        public float getPlayerHpRatio()
        {
            return player.getHpRatio();
        }

        public void decreasePlayerHp(int hitValue)
        {
            player.decreaseHp(hitValue);
        }
        public float getEnemyHpRatio()
        {
            return enemy.getHpRatio();
        }

        void Update()
        {
            foreach (var cmd in commands)
            {
                switch (cmd)
                {
                    case PlayerCommandTurnEnd:
                        if (turn.Turn is Data.TurnType.Player)
                            turn.ChangeTurn();
                        break;
                    case EnemyCommandTurnEnd:
                        if (turn.Turn is Data.TurnType.Enemy)
                            turn.ChangeTurn();
                        break;
                    case PlayerCommandAttack:
                        Debug.Log(player.damage +" 로 공격 성공");
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
                        Debug.Log($"Not implemented {cmd}");
                        break;
                }
            }
            commands.Clear();
        }

        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
        }
    }
}
