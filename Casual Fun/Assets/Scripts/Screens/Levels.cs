using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Levels : MonoBehaviour
    {
        public void OnClose() => SceneLoader.UnloadScene(SceneNames.Levels);
    }
}
