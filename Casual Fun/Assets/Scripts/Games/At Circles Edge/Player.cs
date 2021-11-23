using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Player : GameBehaviour
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

        void OnTriggerEnter2D(Collider2D other)
        {
            var (hasHit, collision) = HasHitSomethingOfInterest(other);
            if (!hasHit) return;
            collision.Collide(other.gameObject);
        }

        static (bool, ICollidable) HasHitSomethingOfInterest(Component other)
        {
            var collision = other.GetComponent<ICollidable>();
            return collision is null ? (false, null) : (true, collision);
        }
    }
}
