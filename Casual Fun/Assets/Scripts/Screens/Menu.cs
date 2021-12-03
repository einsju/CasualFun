using System.Collections.Generic;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] GameObject mainScreen;
        [SerializeField] GameObject optionsScreen;
        [SerializeField] GameObject leaderboardScreen;

        ScreenManager _screenManager;

        void Start() => _screenManager = new ScreenManager(new List<GameObject> { mainScreen, optionsScreen, leaderboardScreen });
        public void OnOptions() => OpenScreenWithAnimation(optionsScreen);
        public void OnLeaderboard() => OpenScreenWithAnimation(leaderboardScreen);
        public void OnHome() => OpenScreenWithAnimation(mainScreen);

        void OpenScreenWithAnimation(GameObject screen)
        {
            _screenManager.OpenScreen(screen);
            EventManager.OnScreenOpened();
        }
    }
}
