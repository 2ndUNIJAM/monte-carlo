using System;
using MonteCarlo.Data;
using MonteCarlo.Struct;
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
            }

            Debug.Log($"Not Implemented Command {type}");
            throw new NotImplementedException();
        }
    }
}
