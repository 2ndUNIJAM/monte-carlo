using UnityEngine;
using TMPro;
using MonteCarlo.Data;
using MonteCarlo.Core;

namespace MonteCarlo.UI
{
    public class TurnPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnText;

        private void Start()
        {
            turnText = GetComponent<TextMeshProUGUI>();
            turnText.text = "my turn";
        }

        private string GetTurnString()
        {
            string result = "";
            if (MainFlowBehaviour.Instance.Turn is TurnType.Player)
            {
                result = "my turn";
            }
            else if (MainFlowBehaviour.Instance.Turn is TurnType.Enemy)
            {
                result = "enemy turn";
            }
            return result;
        }

        public void Update()
        {
            turnText.text = GetTurnString();
        }
    }
}
