using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                var cmd = CommandGenerator.Generate(type);
                MainFlowBehaviour.Instance.AddCommand(cmd);
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
                case CommandType.RevolverGunTurnEnd:
                    break;
                default:
                    break;
            }
        }

        private void changeActionButton(int value, float probability, int spriteIdx)
        {
            valueText.text = $"{value.ToString()}";
            probabilityText.text = $"{probability.ToString()}%";
            cardImage.sprite = cardResourceImage[spriteIdx];
        }
    }
}
