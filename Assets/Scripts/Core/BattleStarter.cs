using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleStarter : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] BattleDataHolder dataHolder;

    void Start()
    {
        DontDestroyOnLoad(dataHolder);

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
