using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;

namespace MonteCarlo.Expression
{
    public class ExpressionHP : MonoBehaviour
    {
        [SerializeField] private CommandType type;

        private void OnEnable()
        {

        }

        void Update()
        {
        }

        // TODO: 애니메이션 종료시 호출되도록.
        private void Callback()
        {
            var cmd = CommandGenerator.Generate(type);
            MainFlowBehaviour.Instance.AddCommand(cmd);
        }
    }

    
}
