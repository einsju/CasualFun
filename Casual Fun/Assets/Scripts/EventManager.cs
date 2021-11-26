using System;

namespace CasualFun
{
    public abstract class EventManager
    {
        public static event Action ScreenOpened;
        public static void OnScreenOpened() => ScreenOpened?.Invoke();
    }
}
