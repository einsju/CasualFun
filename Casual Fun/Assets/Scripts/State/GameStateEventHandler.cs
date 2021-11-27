using System;
using UnityEngine;

namespace CasualFun.State
{
    public abstract class GameStateEventHandler
    {
        public static event Action GameStarted;
        public static void OnGameStarted() => GameStarted?.Invoke();
        
        public static event Action GameOver;
        public static void OnGameOver() => GameOver?.Invoke();
        
        public static event Action<Vector3> PlayerPickedUpCollectable;
        public static void OnPlayerPickedUpCollectable(Vector3 position)
            => PlayerPickedUpCollectable?.Invoke(position);
        
        public static event Action<Vector3> PlayerPickedUpCoin;
        public static void OnPlayerPickedUpCoin(Vector3 position)
            => PlayerPickedUpCoin?.Invoke(position);
        
        public static event Action<Transform> PlayerWasHitByEnemy;

        public static void OnPlayerWasHitByEnemy(Transform playerPosition)
            => PlayerWasHitByEnemy?.Invoke(playerPosition);
    }
}
