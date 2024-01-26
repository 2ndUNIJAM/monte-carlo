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
        private List<ICommand> commands = new();

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
