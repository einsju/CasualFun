using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class PlayerInput : GameStateBehaviour
    {
        [SerializeField] Player player;

        void Update()
        {
            if (!GameStateHandler.GameIsRunning || !Input.GetButtonDown("Fire1")) return;
            player.ChangeDirection();
        }
    }
}
