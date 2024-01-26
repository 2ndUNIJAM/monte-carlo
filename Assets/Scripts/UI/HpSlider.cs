using MonteCarlo.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MonteCarlo.UI
{
    public class HpSlider : MonoBehaviour
    {
        [SerializeField] private Slider HpBarValue;
        private float playerHpValue;

        void Start()
        {
            playerHpValue = MainFlowBehaviour.Instance.getHpRatio();
        }

        void Update()
        {
            playerHpValue = MainFlowBehaviour.Instance.getHpRatio();
            HpBarValue.value = playerHpValue;
        }
    }
}
