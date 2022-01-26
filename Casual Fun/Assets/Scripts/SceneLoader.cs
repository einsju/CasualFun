using UnityEngine.SceneManagement;

namespace CasualFun.AtCirclesEdge
{
    public static class SceneLoader
    {
        public static void LoadScene(string name)
        {
            if (SceneManager.GetSceneByName(name).isLoaded) return;
            TaskDelayAwaiter.Wait(() => SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive));
        }

        public static void UnloadScene(string name)
        {
            if (!SceneManager.GetSceneByName(name).isLoaded) return;
            TaskDelayAwaiter.Wait(() => SceneManager.UnloadSceneAsync(name));
        }
    }
}
