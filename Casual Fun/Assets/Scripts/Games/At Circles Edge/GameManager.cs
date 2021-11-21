using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : MonoBehaviour
    {
        // [SerializeField] Player player;

        void Awake()
        {
            // GameStateEventHandler.GameStarted += GameStarted;
            // GameStateEventHandler.GameOver += GameOver;
        }

        void OnDestroy()
        {
            // GameStateEventHandler.GameStarted -= GameStarted;
            // GameStateEventHandler.GameOver -= GameOver;
        }

        // void GameStarted() => player.Enable(true);
        // void GameOver() => player.Reset();
    }
}
