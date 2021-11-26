using CasualFun.Games.AtCirclesEdge;
using CasualFun.State;
using UnityEngine;

public class PlayerInput : GameStateBehaviour
{
    [SerializeField] Player player;

    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        player.ChangeDirection();
    }
}
