using CasualFun;
using CasualFun.Games.AtCirclesEdge;
using UnityEngine;

public class PlayerInput : GameBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        playerMovement.ChangeDirection();
    }
}
