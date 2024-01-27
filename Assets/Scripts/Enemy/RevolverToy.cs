using UnityEngine;
using MonteCarlo.Core;

namespace MonteCarlo.Enemy
{
    public class RevolverToy
    {
        private readonly int maxProbability = 6;
        // 1/6 -> 1/5 -> ...
        public int attackProbability;

        public RevolverToy()
        {
            this.attackProbability = this.maxProbability;
        }

        private float getProbability()
        {
            return 1 / (float)attackProbability;
        }

        private void avoid()
        {
            //Debug.Log("틱");
        }
        private void attack()
        {
            MainFlowBehaviour.Instance.decreasePlayerHp(50);
            //Debug.Log("빵");
        }

        public void revolverAttack()
        {
            // 랜덤 확률로 공격 여부 결정
            if (Random.Range(0f, 1f) < getProbability())
            {
                attack();
                attackProbability = 6;
            }
            else
            {
                avoid();
                attackProbability--;
            }
        }
    }
}
