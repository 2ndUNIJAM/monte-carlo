using UnityEngine;

namespace MonteCarlo.Data
{
    [CreateAssetMenu(fileName = "EnemyMasterData", menuName = "ScriptableObjects/EnemyMasterData")]
    public class EnemyMasterDataModel : ScriptableObject
    {
        public int MaxHP;
        public EnemyActionType[] actionTypes;
    }
}
