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
                animator.Play("Shoot");

                while (true)
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot") &&
                    animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        Debug.Log("콜백실행");
                        Callback();
                        break;
                    }
                }
                
                Debug.Log("ㄱㄱ");
            }
            else
            {
                // 임시
                Callback();
            }
        }

        // TODO: 애니메이션 종료시 호출되도록.
        private void Callback()
        {
            Debug.Log("콜백");
            var cmd = CommandGenerator.Generate(type);
            MainFlowBehaviour.Instance.AddCommand(cmd);
        }
    }
}
