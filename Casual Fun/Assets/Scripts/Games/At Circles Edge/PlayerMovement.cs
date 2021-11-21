using System;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class PlayerMovement : GameBehaviour
    {
        public static event Action<float> PlayerChangedDirection;
        
        [SerializeField] float speed = 100;
        [SerializeField] Transform objectToMove;
        [SerializeField] SpriteRenderer playerSprite;

        void OnEnable() => ResetRotation(objectToMove);

        // Notify direction change when started to avoid having a change before getting the value 
        void Start() => PlayerChangedDirection?.Invoke(speed);

        void Update() => objectToMove.Rotate(0, 0, speed * Time.unscaledDeltaTime);

        public void ChangeDirection()
        {
            speed *= -1;
            playerSprite.flipX = speed < 0;
            PlayerChangedDirection?.Invoke(speed);
        }
    }
}
