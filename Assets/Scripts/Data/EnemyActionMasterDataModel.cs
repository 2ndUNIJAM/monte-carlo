using MonteCarlo.Struct;
using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "EnemyActionMasterDataModel", menuName = "ScriptableObjects/EnemyActionMasterDataModel")]
    public class EnemyActionMasterDataModel : ScriptableObject
    {
        [Header("Revolver")]
        public RevolverActionData Revolver;

        [Header("Dice")]
        public DiceAttackData DiceAttack;
        public DiceHealData DiceHeal;

        [Header("Box")]
        public BoxActionData Box;
    }
}
