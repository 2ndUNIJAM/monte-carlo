using UnityEngine;
using TMPro;
using MonteCarlo.Core;

namespace MonteCarlo.UI
{
    public class DefencePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI defenceText;

        private void Start()
        {
            defenceText = GetComponent<TextMeshProUGUI>();
            defenceText.text = "";
        }

        private string GetTurnString()
        {
            var tmp = MainFlowBehaviour.Instance.getPlayerDefence();
            var texttmp = tmp <= 0.0 ? "00" : tmp.ToString();
            return $"+{texttmp}";
        }

        public void Update()
        {
            defenceText.text = GetTurnString();
        }
    }
}
