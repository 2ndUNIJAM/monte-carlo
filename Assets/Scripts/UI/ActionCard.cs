using MonteCarlo.Core;
using MonteCarlo.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace MonteCarlo.UI
{
    public class ActionCard : MonoBehaviour
    {
        private EnemyMasterDataModel enemyData => BattleDataHolder.Instance.Enemy;

        [SerializeField] private CommandType type;
        [SerializeField] private Sprite[] cardResourceImage;
        private Image cardImage;

        private bool coroutineAllowed;
        private float delayTimer = 0.0f;

        private void Start()
        {
            coroutineAllowed = true;
            cardImage = GetComponent<Image>();
            //var mainFlow = MainFlowBehaviour.Instance;
            //var prob = mainFlow.getEnemyProbability();

            // 적 종류 먼저 분기
            switch (enemyData.Type)
            {
                //case EnemyType.Revolver:
                //    {
                //        if (prob <= 1 / 6.0f)
                //        {
                //            Debug.Log("1/6");
                //            var imageIndex = 5;
                //            changeActionCard(imageIndex);
                //        }
                //        else if (prob <= 1 / 5.0f)
                //        {
                //            Debug.Log("1/5");
                //            var imageIndex = 4;
                //            changeActionCard(imageIndex);
                //        }
                //        else if (prob <= 1 / 4.0f)
                //        {
                //            Debug.Log("1/4");
                //            var imageIndex = 3;
                //            changeActionCard(imageIndex);
                //        }
                //        else if (prob <= 1 / 3.0f)
                //        {
                //            Debug.Log("1/3");
                //            var imageIndex = 2;
                //            changeActionCard(imageIndex);
                //        }
                //        else if (prob <= 1 / 2.0f)
                //        {
                //            Debug.Log("1/2");
                //            var imageIndex = 1;
                //            changeActionCard(imageIndex);
                //        }
                //        else if (prob <= 1 / 1.0f)
                //        {
                //            Debug.Log("1/1");
                //            var imageIndex = 0;
                //            changeActionCard(imageIndex);
                //        }
                //        break;
                //    }
                case EnemyType.Dice:

                    break;
            }
        }
        private void Update()
        {
            if (MainFlowBehaviour.Instance.Turn is TurnType.EnemyRandomRoll)
            {
                delayTimer -= Time.deltaTime;
                if (delayTimer > 0) return;

                if (coroutineAllowed)
                {
                    StartCoroutine(RotateCard());
                }
                delayTimer = 1.0f;
            }
        }

        private IEnumerator RotateCard()
        {
            coroutineAllowed = false;
            for (float i = 0f; i <= 90f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    // 적 종류 먼저 분기
                    switch (enemyData.Type)
                    {
                        //case EnemyType.Revolver:
                        //    {
                        //        if (prob <= 1 / 6.0f)
                        //        {
                        //            Debug.Log("1/6");
                        //            var imageIndex = 5;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        else if (prob <= 1 / 5.0f)
                        //        {
                        //            Debug.Log("1/5");
                        //            var imageIndex = 4;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        else if (prob <= 1 / 4.0f)
                        //        {
                        //            Debug.Log("1/4");
                        //            var imageIndex = 3;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        else if (prob <= 1 / 3.0f)
                        //        {
                        //            Debug.Log("1/3");
                        //            var imageIndex = 2;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        else if (prob <= 1 / 2.0f)
                        //        {
                        //            Debug.Log("1/2");
                        //            var imageIndex = 1;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        else if (prob <= 1 / 1.0f)
                        //        {
                        //            Debug.Log("1/1");
                        //            var imageIndex = 0;
                        //            changeActionCard(imageIndex);
                        //        }
                        //        break;
                        //    }
                        case EnemyType.Dice:

                            break;
                    }
                }
                yield return new WaitForSeconds(0.01f);
            }
            for (float i = 90f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.01f);
            }
            coroutineAllowed = true;
        }



        private void changeActionCard(int spriteIdx)
        {
            cardImage.sprite = cardResourceImage[spriteIdx];
        }
    }
}
