using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonteCarlo.Core
{
    public class BattleStarter : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] BattleDataHolder dataHolder;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                LoadBattle();
            });
        }

        public void LoadBattle()
        {
            SceneManager.LoadScene("Battle");
        }
    }
}
