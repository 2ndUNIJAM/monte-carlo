using MonteCarlo.Core;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour
{
    private Slider HpBarValue;
    private float playerHpValue;

    void Start()
    {
        HpBarValue = GetComponent<Slider>();
        playerHpValue = MainFlowBehaviour.Instance.getHpRatio();
    }

    void Update()
    {
        playerHpValue = MainFlowBehaviour.Instance.getHpRatio();
        HpBarValue.value = playerHpValue;
    }
}
