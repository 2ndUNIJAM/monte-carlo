using MonteCarlo.Core;
using MonteCarlo.Data;
using UnityEngine;

namespace MonteCarlo.Expression
{
    public class ExpressionController : MonoBehaviour
    {
        [SerializeField] private GameObject playerRoll;
        [SerializeField] private GameObject playerResult;
        [SerializeField] private GameObject enemyRoll;
        [SerializeField] private GameObject enemyResult;

        // 이벤트 받아서 동작하는게 좋은데, 당장은 그런거 구현할 여력이 없다.
        private void Update()
        {
            var turn = MainFlowBehaviour.Instance.Turn;

            if (turn is TurnType.Player || turn is TurnType.Enemy)
            {
                playerRoll.SetActive(false);
                playerResult.SetActive(false);
                enemyRoll.SetActive(false);
                enemyResult.SetActive(false);
            }

            if (turn is TurnType.PlayerRandomRoll)
            {
                playerRoll.SetActive(true);
                playerResult.SetActive(false);
                enemyRoll.SetActive(false);
                enemyResult.SetActive(false);
            }


            if (turn is TurnType.PlayerActionResult)
            {
                playerRoll.SetActive(false);
                playerResult.SetActive(true);
                enemyRoll.SetActive(false);
                enemyResult.SetActive(false);
            }

            if (turn is TurnType.EnemyRandomRoll)
            {
                playerRoll.SetActive(false);
                playerResult.SetActive(false);
                enemyRoll.SetActive(true);
                enemyResult.SetActive(false);
            }

            if (turn is TurnType.EnemyActionResult)
            {
                playerRoll.SetActive(false);
                playerResult.SetActive(false);
                enemyRoll.SetActive(false);
                enemyResult.SetActive(true);
            }
        }
    }
}
