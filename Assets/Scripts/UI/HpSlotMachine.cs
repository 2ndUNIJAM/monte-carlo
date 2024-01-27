using System.Collections;
using UnityEngine;
using MonteCarlo.Core;

public class HpSlotMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] SlotSkillObject;
    [SerializeField] private GameObject[] Slot;

    private int DisplayHp = 123;

    private int Hp_1, Hp_2, Hp_3;

    private readonly int[] answer = { 0, 0, 0 };

    private void Update()
    {
        var Hp = MainFlowBehaviour.Instance.PlayerHp;
        if (DisplayHp != Hp)
        {
            OnHpChanged(Hp);
        }
    }

    private void OnHpChanged(int Hp)
    {
        DisplayHp = Hp;
        Hp_1 = DisplayHp / 100;
        Hp_2 = DisplayHp % 100 / 10;
        Hp_3 = DisplayHp % 10;

        answer[0] = Hp_1;
        answer[1] = Hp_2;
        answer[2] = Hp_3;

        for (int i = 0; i < Slot.Length; i++)
        {
            StartCoroutine(StartSlot(i));
        }
    }

    private IEnumerator StartSlot(int SlotIndex)
    {
        Debug.Log(SlotSkillObject[SlotIndex].transform.localPosition);

        var repeatCount = (Slot.Length * 2 + Slot.Length - answer[SlotIndex] + 1 + SlotIndex * 10) * 2;

        for (int i = 0; i < repeatCount; i++)
        {
            SlotSkillObject[SlotIndex].transform.localPosition -= new Vector3(0, 50f, 0);
            if (SlotSkillObject[SlotIndex].transform.localPosition.y < 0f)
            {
                SlotSkillObject[SlotIndex].transform.localPosition += new Vector3(0, 1000f, 0);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

}
