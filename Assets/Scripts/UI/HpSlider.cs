using MonteCarlo.Core;
using MonteCarlo.Data;
using UnityEngine;
using UnityEngine.UI;

namespace MonteCarlo.UI
{
    public class HpSlider : MonoBehaviour
    {
        [SerializeField] private CharacterType character;// enum name
        [SerializeField] private Slider HpBarValue;
        private float HpValue;

        void Update()
        {
            if (character is CharacterType.Player)
            {
                HpValue = MainFlowBehaviour.Instance.PlayerHpRatio;
            }
            else if (character is CharacterType.Enemy)
            {
                HpValue = MainFlowBehaviour.Instance.EnemyHpRatio;
            }
            HpBarValue.value = HpValue;
        }
    }
}
