using System;
using MonteCarlo.Data;
using MonteCarlo.Struct.Command;
using UnityEngine;

namespace MonteCarlo.Util
{
    public static class CommandGenerator
    {
        public static ICommand Generate(CommandType type)
        {
            switch (type)
            {
                case CommandType.PlayerTurnEnd:
                    return new PlayerCommandTurnEnd();
                case CommandType.EnemyTurnEnd:
                    return new EnemyCommandTurnEnd();
                case CommandType.RevolverGunTurnEnd:
                    return new EnemyCommandAction(EnemyActionType.Revolver);
                case CommandType.PlayerAttack:
                    return new PlayerCommandAttack();
                case CommandType.PlayerDefence:
                    return new PlayerCommandDefence();
                case CommandType.PlayerHeal:
                    return new PlayerCommandHeal();
                case CommandType.PlayerRollEnd:
                    return new PlayerCommandRollEnd();
                case CommandType.PlayerResultEnd:
                    return new PlayerCommandResultEnd();
                case CommandType.EnemyRollEnd:
                    return new EnemyCommandRollEnd();
                case CommandType.EnemyResultEnd:
                    return new EnemyCommandResultEnd();
            }

            Debug.Log($"Not Implemented Command {type}");
            throw new NotImplementedException();
        }
    }
}
