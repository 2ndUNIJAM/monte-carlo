using UnityEngine;

namespace MonteCarlo.Core
{
    public class BattleSceneHelper : MonoBehaviour
    {
        [SerializeField] private GameObject dataHolder;

        private void Awake()
        {
            var helper = GameObject.Find("/BattleDataHolder (Singleton)");
            if (helper == null)
            {
                var holder = Instantiate(dataHolder);
                holder.name = "BattleDataHolder (Singleton)";
            }
        }
    }
}
