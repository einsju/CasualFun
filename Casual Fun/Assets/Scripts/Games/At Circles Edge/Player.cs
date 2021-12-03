using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Player : GameStateBehaviour, IKillable
    {
        [SerializeField] float speed = 100;
        [SerializeField] Transform playerBase;

        SpriteRenderer _spriteRenderer;
        Collider2D _collider;

        public override void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            base.Awake();
        }

        void OnEnable()
        {
            ResetRotation(playerBase);
            _spriteRenderer.enabled = _collider.enabled = true;
        }

        void Update() => Move();
        
        void Move() => playerBase.Rotate(0, 0, speed * Time.unscaledDeltaTime);

        public void ChangeDirection()
        {
            speed *= -1;
            _spriteRenderer.flipX = speed < 0;
        }

        public float Speed => speed;

        void OnTriggerEnter2D(Collider2D other) => other.GetComponent<ICollectable>()?.Collect();

        public void Kill()
        {
            _spriteRenderer.enabled = _collider.enabled = false;
            GameStateEventHandler.OnPlayerWasHitByEnemy(transform);
        }
    }
}
