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
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}
