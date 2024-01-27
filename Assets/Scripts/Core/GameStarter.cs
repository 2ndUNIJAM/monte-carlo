using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonteCarlo.Core
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] Button button;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                LoadBattle();
            });
        }

        public void LoadBattle()
        {
            SceneManager.LoadScene("BattleBase", LoadSceneMode.Single);
        }
    }
}
