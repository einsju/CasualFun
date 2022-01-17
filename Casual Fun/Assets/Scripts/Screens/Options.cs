using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Options : MonoBehaviour
    {
        public void OnRate() => Application.OpenURL("market://details?id=com.einarsen.casualfun");
        public void OnPrivacy() => Application.OpenURL("https://sjureinarsen.wixsite.com/casualfun/privacypolicy");
        public void OnQuit() => Application.Quit();
    }
}
