using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonteCarlo.Player;
using MonteCarlo.Core;

public class HpSlotMachine : MonoBehaviour
{
    public GameObject[] SlotSkillObject;
    public GameObject[] Slot;

    public GameObject[] Slot1;
    public GameObject[] Slot2;
    public GameObject[] Slot3;

    public List<int> StartList = new List<int> ( );
    public List<int> ResultIndexList = new List<int> ( );

    public int ItemCnt = 3;

    public int Hp = 123;

    public int Hp_1;
    public int Hp_2;
    public int Hp_3;

    public int[] answer = { 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        Hp = MainFlowBehaviour.Instance.PlayerHp;
        if (Hp >= 100) // 세 자리 자연수일 때는 
        {
            Hp_1 = Hp / 100;
        }
        else
        {
            Hp_1 = 0;
        }
        Hp_3 = Hp % 10;
        Hp_2 = (Hp % 100) / 10;

        answer[0] = Hp_1;
        answer[1] = Hp_2;
        answer[2] = Hp_3;

        for ( int i = 0 ; i < ItemCnt * Slot.Length; i++ )
        {
            StartList.Add ( i );
        }

        for ( int i = 0 ; i < Slot.Length; i++ )
        {
            StartCoroutine ( StartSlot ( i ) );
        }
    }
    
    IEnumerator StartSlot ( int SlotIndex )
    {
        Debug.Log(SlotSkillObject[SlotIndex].transform.localPosition);
        for ( int i = 0 ; i < ( Slot.Length * 2 + (Slot.Length - answer[SlotIndex]+1) + SlotIndex * 10 ) * 2 ; i++ )
        {
            SlotSkillObject[SlotIndex].transform.localPosition -= new Vector3 ( 0, 50f, 0 );
            if ( SlotSkillObject[SlotIndex].transform.localPosition.y < 0f )
            {
                SlotSkillObject[SlotIndex].transform.localPosition += new Vector3 ( 0, 1000f, 0 );
            }
            yield return new WaitForSeconds ( 0.05f );
        }
    }

}