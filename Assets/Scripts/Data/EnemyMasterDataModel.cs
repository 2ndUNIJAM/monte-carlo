using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "EnemyMasterData", menuName = "ScriptableObjects/EnemyMasterData")]
    public class EnemyMasterDataModel : ScriptableObject
    {
        public int MaxHP;

        [Header("Revolver")]
        public RevolverActionData Revolver;

        [Header("Dice")]
        public DiceAttackData DiceAttack;
        public DiceHealData DiceHeal;
    }
}
