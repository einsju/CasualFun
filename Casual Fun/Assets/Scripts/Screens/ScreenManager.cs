using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class ScreenManager
    {
        public static event Action ScreenOpened;
        
        readonly IList<GameObject> _screens;
        GameObject ActiveScreen => _screens.First(s => s.activeSelf);

        public ScreenManager(IList<GameObject> screens) => _screens = screens;

        public void OpenScreen(GameObject screen)
        {
            if (!_screens.Any()) return;
            CloseActiveScreen();
            screen.SetActive(true);
            ScreenOpened?.Invoke();
        }
        
        void CloseActiveScreen() => ActiveScreen.SetActive(false);
    }
}
