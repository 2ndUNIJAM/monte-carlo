using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MonteCarlo.Core
{
    public class BackToTitle : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] Button CreditButton;
        [SerializeField] GameObject Credit;

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

        public void LoadCredit()
        {
            Credit.SetActive(true);
        }

        public void CreditClose()
        {
            Credit.SetActive(false);
        }
    }
}
