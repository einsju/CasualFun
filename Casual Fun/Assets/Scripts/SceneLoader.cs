using UnityEngine;
using UnityEngine.SceneManagement;

namespace CasualFun
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string name) => SceneManager.LoadScene(name);
    }
}
