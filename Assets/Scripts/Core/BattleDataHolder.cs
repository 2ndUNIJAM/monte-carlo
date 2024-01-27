using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class BattleDataHolder : SingletonBehaviour<BattleDataHolder>
    {
        public PlayerMasterDataModel Player;
        public EnemyMasterDataModel Enemy;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
