using UnityEngine;
using TMPro;
using MonteCarlo.Core;

namespace MonteCarlo.UI
{
    public class TurnPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnText;

        private void Start()
        {
            turnText = GetComponent<TextMeshProUGUI>();
            turnText.text = "";
        }

        private string GetTurnString()
        {
            return MainFlowBehaviour.Instance.Turn.ToString();
        }

        public void Update()
        {
            turnText.text = GetTurnString();
        }
    }
}
