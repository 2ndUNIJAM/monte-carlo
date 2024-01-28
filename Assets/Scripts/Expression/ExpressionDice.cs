using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;

namespace MonteCarlo.Expression
{
    public class ExpressionDice : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CommandType type;
        [SerializeField] private DiceChange diceChange;
        private float delay = 3f;

        private void OnEnable()
        {
            // TODO: 애니메이션 재생.
            if (animator != null)
            {
                animator.Play("Execute");
                diceChange.ChangeImage(Random.Range(0, 5));
            }
            else
            {
                // 임시
                // Callback();
                delay = 3f;
            }
        }

        void Update()
        {
            if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    Callback();
                }
            }
            else
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    Callback();
                }
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
