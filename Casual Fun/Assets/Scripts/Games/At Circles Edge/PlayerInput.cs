using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class PlayerInput : GameStateBehaviour
    {
        [SerializeField] Player player;

        void Update()
        {
            if (!Input.GetButtonDown("Fire1")) return;
            player.ChangeDirection();
        }
    }
}
