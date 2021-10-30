using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CasualFun.Managers
{
    public class ScreenManager
    {
        readonly IList<GameObject> _screens;
        GameObject CurrentlyActive => _screens.First(s => s.activeSelf);

        public ScreenManager(IList<GameObject> screens) => _screens = screens;

        public void OpenScreen(GameObject screen)
        {
            if (!_screens.Any()) return;
            CloseCurrentlyActiveScreen();
            screen.SetActive(true);
        }
        
        void CloseCurrentlyActiveScreen() => CurrentlyActive.SetActive(false);
    }
}
