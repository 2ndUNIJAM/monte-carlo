using System.Collections.Generic;
using MonteCarlo.Player;
using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Core
{
    // TODO: singleton.
    public class MainFlowBehaviour : MonoBehaviour
    {
        private TurnStateMachine turn;
        private PlayerBase player;
        private readonly List<ICommand> commands = new();

        void Awake()
        {
            turn = new TurnStateMachine();
            player = new PlayerBase();

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
