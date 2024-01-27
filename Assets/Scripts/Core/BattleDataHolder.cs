using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class BattleDataHolder : SingletonBehaviour<BattleDataHolder>
    {
        public PlayerMasterDataModel Player;
        public EnemyMasterDataModel Enemy;
        public EnemyActionMasterDataModel EnemyAction;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
