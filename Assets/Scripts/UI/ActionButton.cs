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

            MainFlowBehaviour mainFlow = MainFlowBehaviour.Instance;
            switch (type)
            {
                case CommandType.PlayerAttack:
                    {
                        changeActionButton(mainFlow.getPlayerAttackDamage(), mainFlow.getPlayerAttackProbability(), 0);
                        break;
                    }
                case CommandType.PlayerDefence:
                    {
                        changeActionButton(mainFlow.getPlayerDefenceAmount(), mainFlow.getPlayerAttackProbability(), 2);
                        break;
                    }
                case CommandType.PlayerHeal:
                    {
                        changeActionButton(mainFlow.getPlayerHealAmount(), mainFlow.getPlayerHealProbability(), 4);
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
