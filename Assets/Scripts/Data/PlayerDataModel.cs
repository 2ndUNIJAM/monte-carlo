using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
    public class PlayerDataModel : ScriptableObject
    {
        public int PlayerMaxHP;

        public int PlayerChanceNumerator;
        const int PlayerChanceDenominator = 1000;

        public int PlayerMoney;


        // 통계
        public int PlayerCoinSuccess;
        public int PlayerCoinFail;

        public int[] PlayerActionCount = { 0, 0, 0, 0 };

    }
}
