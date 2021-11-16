using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CasualFun.Managers
{
    public class ScreenManager
    {
        readonly IList<GameObject> _screens;
        GameObject ActiveScreen => _screens.First(s => s.activeSelf);

        public ScreenManager(IList<GameObject> screens) => _screens = screens;

        public void OpenScreen(GameObject screen)
        {
            if (!_screens.Any()) return;
            CloseActiveScreen();
            screen.SetActive(true);
        }
        
        void CloseActiveScreen() => ActiveScreen.SetActive(false);
    }
}
