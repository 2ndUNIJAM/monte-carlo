using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "PlayerMasterData", menuName = "ScriptableObjects/PlayerMasterData")]
    public class PlayerMasterDataModel : ScriptableObject
    {
        public int PlayerMaxHP;
        public int HealAmount;

        [Header("Attack")]
        public AttackData Attack;
    }
}
