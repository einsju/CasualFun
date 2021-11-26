using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Player : GameStateBehaviour, IKillable
    {
        [SerializeField] float speed = 100;
        [SerializeField] Transform playerBase;
        [SerializeField] SpriteRenderer playerSprite;

        void OnEnable() => ResetRotation(playerBase);

        void Update() => Move();
        
        void Move() => playerBase.Rotate(0, 0, speed * Time.unscaledDeltaTime);

        public void ChangeDirection()
        {
            speed *= -1;
            playerSprite.flipX = speed < 0;
        }

        public float Speed => speed;

        void OnTriggerEnter2D(Collider2D other) => other.GetComponent<ICollectable>()?.Collect();

        public void Kill() => GameStateEventHandler.OnPlayerWasHitByEnemy(transform);
    }
}
