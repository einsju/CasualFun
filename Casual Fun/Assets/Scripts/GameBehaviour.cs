using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun
{
    public class GameBehaviour : MonoBehaviour
    {
        [SerializeField] bool disableAtStartup = true;
        
        public virtual void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            enabled = !disableAtStartup;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
        }

        void GameStarted() => enabled = true;
        void GameOver() => enabled = false;

        protected static void ResetRotation(Transform transformToReset)
            => transformToReset.rotation = Quaternion.identity;
    }
}
