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
                    return new RevolverGunCommandTurnEnd();
                case CommandType.PlayerAttack:
                    return new PlayerCommandAttack();
                case CommandType.PlayerDefence:
                    return new PlayerCommandDefence();
                case CommandType.PlayerHeal:
                    return new PlayerCommandHeal();
            }

            Debug.Log($"Not Implemented Command {type}");
            throw new NotImplementedException();
        }
    }
}
