using UnityEngine;

namespace CasualFun.State
{
    public class GameStateElement : MonoBehaviour
    {
        void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
        }

        void GameStarted() => gameObject.SetActive(false);
        void GameOver() => gameObject.SetActive(true);
    }
}
