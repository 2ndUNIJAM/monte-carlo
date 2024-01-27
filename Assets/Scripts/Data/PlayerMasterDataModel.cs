using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "PlayerMasterData", menuName = "ScriptableObjects/PlayerMasterData")]
    public class PlayerMasterDataModel : ScriptableObject
    {
        public int MaxHP;

        [Header("Attack")]
        public AttackData Attack;
        [Header("Defence")]
        public DefenceData Defence;
        [Header("Heal")]
        public HealData Heal;
    }
}
