using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;

namespace MonteCarlo.Expression
{
    public class ExpressionPlayer : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CommandType type;

        private void OnEnable()
        {
            // TODO: 애니메이션 재생.
            if (animator !=null)
            {
                animator.Play("Execute");
            }
            else
            {
                // 임시
                Callback();
            }
        }

        void Update()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f),
            {
                Callback();
            }
        }

        // TODO: 애니메이션 종료시 호출되도록.
        private void Callback()
        {
            var cmd = CommandGenerator.Generate(type);
            MainFlowBehaviour.Instance.AddCommand(cmd);

        }
    }

    
}
