using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/playerScriptableObject", order = 1)]
public class playerScriptableObject : ScriptableObject
{
    public int playerHP;

    public int PlayerChanceNumerator;
    const int PlayerChanceDenominator = 1000;

    public int PlayerMoney;


    // 통계
    public int PlayerCoinSuccess;
    public int PlayerCoinFail;

    public int[] PlayerActionCount = { 0, 0, 0, 0 };

}
