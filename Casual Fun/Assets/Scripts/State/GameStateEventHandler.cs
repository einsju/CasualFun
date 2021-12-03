using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public abstract class GameStateEventHandler
    {
        public static event Action GameStarted;
        public static void OnGameStarted() => GameStarted?.Invoke();
        
        public static event Action GameOver;
        public static void OnGameOver() => GameOver?.Invoke();
    }
}
