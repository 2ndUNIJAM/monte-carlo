using MonteCarlo.Core;
using MonteCarlo.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MonteCarlo.UI
{
    public class ActionCard : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private CommandType type;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private TextMeshProUGUI probabilityText;
        [SerializeField] private Sprite[] cardResourceImage;
        private Image cardImage;

        const int MULTIPLER = 100;

        private float DelayTimer = 1.0f; // 임시

        void Update()
        {
            var mainFlow = MainFlowBehaviour.Instance;
            //if (mainFlow.Turn is TurnType.Player) return;
            DelayTimer -= Time.deltaTime;

            cardImage = GetComponent<Image>();
            switch (mainFlow.Turn)
            {
                case TurnType.EnemyRandomRoll:
                case TurnType.EnemyActionResult:
                    {
                        var value = 0;
                        var probability = 0.0f;
                        var imageIndex = 1;
                        changeActionButton(value, probability, imageIndex);

                        break;
                    }
                default:
                    {
                        switch (type)
                        {
                            case CommandType.EnemyRevolverAction:
                                {
                                    if (DelayTimer > 0) return;
                                    DelayTimer = 1.0f;

                                    var value = 50;
                                    var probability = 0.2f;
                                    var imageIndex = 0;
                                    changeActionButton(value, probability, imageIndex);
                                    break;
                                }
                            // 나중에 heal 추가
                            default:
                                break;
                        }
                        break;
                    }
            }
        }

        private void changeActionButton(int value, float probability, int spriteIdx)
        {
            valueText.text = $"{value.ToString()}";
            probabilityText.text = $"{(probability * MULTIPLER).ToString()}%";
            cardImage.sprite = cardResourceImage[spriteIdx];
        }
    }


}
