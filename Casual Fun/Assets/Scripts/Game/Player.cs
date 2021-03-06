using CasualFun.AtCirclesEdge.Abstractions;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class Player : GameStateBehaviour, IKillable
    {
        [SerializeField] float speed = 100f;
        [SerializeField] Transform playerBase;

        SpriteRenderer _spriteRenderer;
        Collider2D _collider;

        public override void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            base.Awake();
        }

        protected override void OnGameStarted()
        {
            base.OnGameStarted();
            _spriteRenderer.enabled = _collider.enabled = true;
            ResetRotation();
        }

        protected override void OnGameOver()
        {
            base.OnGameOver();
            _spriteRenderer.enabled = _collider.enabled = true;
            ResetRotation();
        }

        void ResetRotation() => playerBase.rotation = Quaternion.identity;

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            Move();
        }

        void Move() => playerBase.Rotate(0, 0, speed * Time.deltaTime);

        public void ChangeDirection()
        {
            speed *= -1;
            _spriteRenderer.flipX = speed < 0;
        }

        public float Speed => speed;

        void OnTriggerEnter2D(Collider2D other) => other.GetComponent<ICollectable>()?.Collect();

        public async void Kill()
        {
            _spriteRenderer.enabled = _collider.enabled = false;
            await GameManager.Instance.PlayerWasHitByEnemy(transform);
        }
    }
}
