using UnityEngine;
using UnityEngine.SceneManagement;

namespace CasualFun.AtCirclesEdge
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string name) => SceneManager.LoadScene(name);
    }
}
