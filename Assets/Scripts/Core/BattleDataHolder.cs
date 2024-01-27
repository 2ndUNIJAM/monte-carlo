using MonteCarlo.Data;

namespace MonteCarlo.Core
{
    public class BattleDataHolder : SingletonBehaviour<BattleDataHolder>
    {
        public PlayerDataModel Player;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
