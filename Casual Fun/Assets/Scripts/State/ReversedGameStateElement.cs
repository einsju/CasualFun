using UnityEngine;

namespace CasualFun.State
{
    public class ReversedGameStateElement : MonoBehaviour
    {
        void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
        }

        void GameStarted() => gameObject.SetActive(true);
        void GameOver() => gameObject.SetActive(false);
    }
}
