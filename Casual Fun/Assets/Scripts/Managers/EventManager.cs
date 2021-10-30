using System;

namespace CasualFun.Managers
{
    public abstract class EventManager
    {
        public static event Action ScreenOpened;

        public static void OnScreenOpened() => ScreenOpened?.Invoke();
    }
}
