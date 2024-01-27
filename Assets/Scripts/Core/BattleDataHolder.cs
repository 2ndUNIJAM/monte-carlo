using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class BattleDataHolder : SingletonBehaviour<BattleDataHolder>
    {
        public PlayerMasterDataModel Player;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
