using UnityEngine;

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

        public float getProbability()
        {
            return 1 / (float)attackProbability;
        }

        private int avoid()
        {
            Debug.Log("틱");
            return 0;
        }
        private int attack()
        {
            Debug.Log("빵");
            return 50;
        }

        public int revolverAttack()
        {
            int attackValue;
            // 랜덤 확률로 공격 여부 결정
            if (Random.Range(0f, 1f) < getProbability())
            {
                attackValue = attack();
                attackProbability = 6;
            }
            else
            {
                attackValue = avoid();
                attackProbability--;
            }
            return attackValue;
        }
    }
}
