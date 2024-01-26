using MonteCarlo.Core;
using MonteCarlo.Data;
using MonteCarlo.Util;
using UnityEngine;
using UnityEngine.UI;

namespace MonteCarlo.UI
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private CommandType type;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                var cmd = CommandGenerator.Generate(type);
                MainFlowBehaviour.Instance.AddCommand(cmd);
            });
        }
    }
}
