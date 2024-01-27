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
        [SerializeField] private TextMeshProUGUI TitleText;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private TextMeshProUGUI probabilityText;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                var cmd = CommandGenerator.Generate(type);
                MainFlowBehaviour.Instance.AddCommand(cmd);
            });

            TitleText.text = "";
            valueText.text = "";
            probabilityText.text = "";
            switch (type)
            {
                case CommandType.PlayerAttack:
                    TitleText.text = "공격";
                    valueText.text = "";
                    probabilityText.text = string.Format("{0}%", getProbabilityText());
                    break;
                case CommandType.PlayerDefence:
                    TitleText.text = "방어";
                    probabilityText.text = "";
                    break;
                case CommandType.PlayerHeal:
                    TitleText.text = "회복";
                    //probabilityText.text =;
                    break;
                case CommandType.RevolverGunTurnEnd:
                    //TitleText.text = ;
                    break;
                default:
                    break;
            }
        }


        private int getProbabilityText()
        {
            return 50;
            //return MainFlowBehaviour.Instance.getPlayerAttackDamage();
        }
    }
}
