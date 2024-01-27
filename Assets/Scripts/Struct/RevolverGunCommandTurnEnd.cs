using MonteCarlo.Core;
using UnityEngine;

namespace MonteCarlo.Struct
{
    public class RevolverGunCommandTurnEnd : IEnemyCommand
    {
        // 1/6 -> 1/5 -> ...
        public int attackProbability;

        void Start()// 이거 실행 안 됨.
        {
            attackProbability = 6;
        }

        private float getProbability()
        {
            return 1 / (float)attackProbability;
        }

        private void avoid()
        {
            Debug.Log("틱");
        }
        private void attack()
        {
            //MainFlowBehaviour.decreasePlayerHp(50);
            Debug.Log("빵");
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

        // 버튼 누르면 cmd 하나 넘어가는 거 짜기
    }
}
