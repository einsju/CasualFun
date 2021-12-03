using System;

namespace CasualFun.AtCirclesEdge
{
    public abstract class EventManager
    {
        public static event Action ScreenOpened;
        public static void OnScreenOpened() => ScreenOpened?.Invoke();
    }
}
