using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Options : MonoBehaviour
    {
        public void OnRate() => TaskDelayAwaiter.Wait(() =>
            Application.OpenURL("market://details?id=com.einarsen.casualfun"));

        public void OnPrivacy() => TaskDelayAwaiter.Wait(() =>
            Application.OpenURL("https://sjureinarsen.wixsite.com/casualfun/privacypolicy"));

        public void OnQuit() => TaskDelayAwaiter.Wait(Application.Quit);

        public void OnClose() => SceneLoader.UnloadScene(SceneNames.Options);
    }
}
