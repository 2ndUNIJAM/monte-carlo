using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Struct.Command;
using MonteCarlo.Util;
using UnityEngine;

public class TurnAi : MonoBehaviour
{
    private EnemyMasterDataModel enemyData => BattleDataHolder.Instance.Enemy;
    private int flag = 0;

    private void Update()
    {
        if (MainFlowBehaviour.Instance.Turn is TurnType.Enemy)
        {
            switch (enemyData.Type)
            {
                case EnemyType.Revolver:
                    Revolver();
                    break;
                case EnemyType.Dice:
                    Dice();
                    break;
            }
        }
    }

    private void Revolver()
    {
        var cmd = CommandGenerator.Generate(CommandType.EnemyRevolverAction);
        MainFlowBehaviour.Instance.AddCommand(cmd);
    }

    private void Dice()
    {
        ICommand cmd;
        if (flag % 2 == 0)
            cmd = CommandGenerator.Generate(CommandType.EnemyDiceAttack);
        else
            cmd = CommandGenerator.Generate(CommandType.EnemyDiceHeal);

        MainFlowBehaviour.Instance.AddCommand(cmd);
        flag++;
    }
}
