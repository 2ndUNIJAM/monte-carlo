using UnityEngine.SceneManagement;

namespace MonteCarlo.Core
{
    public static class BattleEndHelper
    {
        public static void Win(Scene currentScene)
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }

        public static void Defeat()
        {
            BackToTitle();
        }

        private static void BackToTitle()
        {
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
    }
}
