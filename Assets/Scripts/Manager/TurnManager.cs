using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MonteCarlo.Core;
using TMPro;
using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class TurnManager : MonoBehaviour
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
            if (MainFlowBehaviour.Instance.getTurn() is TurnType.Player)
            {
                result= "my turn";
            }
            else if (MainFlowBehaviour.Instance.getTurn() is TurnType.Enemy)
            {
                result= "enemy turn";
            }
            return result;
        }

        public void Update()
        {
            turnText.text = GetTurnString();
        }
    }
}
