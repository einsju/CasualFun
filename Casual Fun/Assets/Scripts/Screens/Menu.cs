using System;
using System.Collections.Generic;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] GameObject mainScreen;
        [SerializeField] GameObject optionsScreen;
        [SerializeField] GameObject leaderboardScreen;
        [SerializeField] GameObject storeScreen;

        ScreenManager _screenManager;
        Camera _camera;

        void Awake() => _camera = Camera.main;

        void Start() => _screenManager = new ScreenManager(new List<GameObject> { mainScreen, optionsScreen, leaderboardScreen, storeScreen });
        public void OnOptions() => OpenScreenWithAnimation(optionsScreen);
        public void OnLeaderboard() => OpenScreenWithAnimation(leaderboardScreen);
        public void OnStore() => OpenScreenWithAnimation(storeScreen);
        public void OnHome() => OpenScreenWithAnimation(mainScreen);

        void OpenScreenWithAnimation(GameObject screen)
        {
            _screenManager.OpenScreen(screen);
            EventManager.OnScreenOpened();
            _camera.enabled = screen == mainScreen;
        }
    }
}
