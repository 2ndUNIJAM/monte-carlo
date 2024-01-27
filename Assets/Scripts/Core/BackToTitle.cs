using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonteCarlo.Core
{
    public class BackToTitle : MonoBehaviour
    {
        [SerializeField] Button button;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                LoadTitle();
            });
        }

        public void LoadTitle()
        {
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
    }
}
