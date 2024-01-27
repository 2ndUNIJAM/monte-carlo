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
            valueText.text = "";
            probabilityText.text = "";
            switch (type)
            {
                case CommandType.PlayerAttack:
                    valueText.text = string.Format("{0}", MainFlowBehaviour.Instance.getPlayerAttackDamage());
                    probabilityText.text = string.Format("{0}%", MainFlowBehaviour.Instance.getPlayerAttackProbability());
                    cardImage.sprite = cardResourceImage[0];
                    break;
                case CommandType.PlayerDefence:
                    valueText.text = string.Format("{0}", MainFlowBehaviour.Instance.getPlayerDefenceDamage());
                    probabilityText.text = string.Format("{0}%", MainFlowBehaviour.Instance.getPlayerDefenceProbability());
                    cardImage.sprite = cardResourceImage[2];
                    break;
                case CommandType.PlayerHeal:
                    valueText.text = string.Format("{0}", MainFlowBehaviour.Instance.getPlayerHealDamage());
                    probabilityText.text = string.Format("{0}%", MainFlowBehaviour.Instance.getPlayerHealProbability());
                    cardImage.sprite = cardResourceImage[4];
                    break;
                case CommandType.RevolverGunTurnEnd:
                    break;
                default:
                    break;
            }
        }
    }
}
