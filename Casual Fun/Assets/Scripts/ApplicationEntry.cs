using UnityEngine;

namespace CasualFun.AtCirclesEdge
{
    public class ApplicationEntry : MonoBehaviour
    {
        void Start()
        {
            // Always start game with options activated 
            SceneLoader.LoadScene("_Menu");
        }
    }
}
