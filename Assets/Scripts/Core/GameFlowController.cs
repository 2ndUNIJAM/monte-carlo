using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonteCarlo.Core
{
    public class GameFlowController : SingletonBehaviour<GameFlowController>
    {
        [SerializeField] private List<string> SceneNames;
        private int idx = 0;

        private void Awake()
        {
            Load();
        }

        private void Load()
        {
            // 마지막씬이 끝난거면 프로그램 종료.
            if (SceneNames.Count <= idx)
            {
                SceneManager.LoadScene("Title", LoadSceneMode.Single);
            }

            var sceneName = SceneNames[idx];
            LoadScene(sceneName);
            idx++;
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnSceneUnloaded(Scene scene)
        {
            Debug.Log("OnSceneUnloaded: " + scene);

            Load();
        }
    }
}
