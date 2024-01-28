using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonteCarlo.Core
{
    public class GameFlowController : SingletonBehaviour<GameFlowController>
    {

        [SerializeField] private List<string> SceneNames;
        private int idx = 0;
        private bool isDefeat = false;

        private void Awake()
        {
            Load();
        }

        private void Load()
        {
            if (isDefeat)
            {
                SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            }
            else
            {
                var sceneName = SceneNames[idx];
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                idx++;

                if (idx < SceneNames.Count)
                    SceneManager.sceneUnloaded += GotoNextScene;
                else
                    SceneManager.sceneUnloaded += GoToWin;
            }
        }

        private void GotoNextScene(Scene scene)
        {
            Debug.Log("OnSceneUnloaded: " + scene.name);
            Load();
            SceneManager.sceneUnloaded -= GotoNextScene;
        }

        private void GoToWin(Scene scene)
        {
            Debug.Log("OnSceneUnloaded: " + scene.name);
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
            SceneManager.sceneUnloaded -= GoToWin;
        }

        public void Defeat()
        {
            isDefeat = true;
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}
