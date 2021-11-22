using CasualFun;
using CasualFun.Games.AtCirclesEdge;
using UnityEngine;

public class PlayerInput : GameBehaviour
{
    [SerializeField] Player player;

    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        player.ChangeDirection();
    }
}
