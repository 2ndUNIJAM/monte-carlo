using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace MonteCarlo.UI
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private CommandType type;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private TextMeshProUGUI probabilityText;
        [SerializeField] private Sprite[] cardResourceImage;
        private Image cardImage;

        private bool facedUp, coroutineAllowed;

        const int MULTIPLER = 100;

        void Start()
        {
            coroutineAllowed = true;
            button.onClick.AddListener(() =>
            {
                var cmd = CommandGenerator.Generate(type);
                MainFlowBehaviour.Instance.AddCommand(cmd);
                StartCoroutine(RotateCardAnim(3f)); // 선택 후 뒤집고, 3초 있다가 다시 뒤집힘
            });

            cardImage = GetComponent<Image>();
            var mainFlow = MainFlowBehaviour.Instance;
            switch (type)
            {
                case CommandType.PlayerAttack:
                    {
                        var value = mainFlow.getPlayerAttackDamage();
                        var probability = mainFlow.getPlayerAttackProbability();
                        var imageIndex = 0;
                        changeActionButton(value, probability, imageIndex);
                        break;
                    }
                case CommandType.PlayerDefence:
                    {
                        var value = mainFlow.getPlayerDefenceAmount();
                        var probability = mainFlow.getPlayerAttackProbability();
                        var imageIndex = 2;
                        changeActionButton(value, probability, imageIndex);
                        break;
                    }
                case CommandType.PlayerHeal:
                    {
                        var value = mainFlow.getPlayerHealAmount();
                        var probability = mainFlow.getPlayerHealProbability();
                        var imageIndex = 4;
                        changeActionButton(value, probability, imageIndex);
                        break;
                    }
                default:
                    break;
            }
        }
        private IEnumerator RotateCardAnim(float delaytime)
        {

            if (coroutineAllowed)
            {
                StartCoroutine(RotateCard());
            }
            yield return new WaitForSeconds(delaytime);
            if (coroutineAllowed)
            {
                StartCoroutine(RotateCard());
            }

        }

        private void changeActionButton(int value, float probability, int spriteIdx)
        {
            valueText.text = $"{value.ToString()}";
            probabilityText.text = $"{(probability * MULTIPLER).ToString()}%";
            cardImage.sprite = cardResourceImage[spriteIdx];
        }
        private void changeActionButtonBack(int spriteIdx)
        {
            valueText.text = "";
            probabilityText.text = "";
            cardImage.sprite = cardResourceImage[spriteIdx];
        }
        private IEnumerator RotateCard()
        {
            coroutineAllowed = false;
            var mainFlow = MainFlowBehaviour.Instance;

            if (!facedUp)
            {
                for (float i = 0f; i <= 180f; i += 10f)
                {
                    transform.rotation = Quaternion.Euler(0f, i, 0f);
                    if (i == 90f)
                    {
                        switch (type)
                        {
                            case CommandType.PlayerAttack:
                                {
                                    var imageIndex = 1;
                                    changeActionButtonBack(imageIndex);
                                    break;
                                }
                            case CommandType.PlayerDefence:
                                {
                                    var imageIndex = 3;
                                    changeActionButtonBack(imageIndex);

                                    break;
                                }
                            case CommandType.PlayerHeal:
                                {
                                    var imageIndex = 5;
                                    changeActionButtonBack(imageIndex);

                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    yield return new WaitForSeconds(0.01f);

                }
            }
            else if (facedUp)
            {
                for (float i = 180f; i >= 0f; i -= 10f)
                {
                    transform.rotation = Quaternion.Euler(0f, i, 0f);
                    if (i == 90f)
                    {
                        switch (type)
                        {
                            case CommandType.PlayerAttack:
                                {
                                    var value = mainFlow.getPlayerAttackDamage();
                                    var probability = mainFlow.getPlayerAttackProbability();
                                    var imageIndex = 0;
                                    changeActionButton(value, probability, imageIndex);
                                    break;
                                }
                            case CommandType.PlayerDefence:
                                {
                                    var value = mainFlow.getPlayerDefenceAmount();
                                    var probability = mainFlow.getPlayerAttackProbability();
                                    var imageIndex = 2;
                                    changeActionButton(value, probability, imageIndex);
                                    break;
                                }
                            case CommandType.PlayerHeal:
                                {
                                    var value = mainFlow.getPlayerHealAmount();
                                    var probability = mainFlow.getPlayerHealProbability();
                                    var imageIndex = 4;
                                    changeActionButton(value, probability, imageIndex);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    yield return new WaitForSeconds(0.01f);
                }
            }

            coroutineAllowed = true;
            facedUp = !facedUp;

            //MainFlowBehaviour.Instance.AddCommand(CommandType);

        }
    }
}
