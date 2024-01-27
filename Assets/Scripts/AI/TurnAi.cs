using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;
public class TurnAi : MonoBehaviour
{
    private float DelayTimer = 1.0f; // 임시
    private void Update()
    {
        if (MainFlowBehaviour.Instance.Turn is TurnType.Enemy)
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer > 0) return;
            DelayTimer = 1.0f;

            var cmd = CommandGenerator.Generate(CommandType.EnemyTurnEnd);
            MainFlowBehaviour.Instance.AddCommand(cmd);
        }
    }
}
