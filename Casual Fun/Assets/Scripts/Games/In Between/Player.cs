using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.InBetween
{
    public class Player : GameStateBehaviour, IKillable
    {
        [SerializeField] float speed = 2200;
        [SerializeField] int offset = 95;

        Rigidbody _rigidbody;
        Transform _transform;

        public override void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        //void OnEnable() => ResetRotation(playerBase);
        
        public void Move(Vector3 direction) => MoveWithinBounds(direction);
        
        public void StopMoving() => _rigidbody.velocity = Vector3.zero;

        void MoveWithinBounds(Vector3 direction)
        {
            _transform.position += Vector3.Lerp(Vector3.zero, direction * speed, 0.1f);
            KeepWithinXBounds();
            KeepWithinYBounds();
        }

        void KeepWithinXBounds()
        {
            if (transform.position.x < -offset)
                _transform.position = new Vector3(-offset, _transform.position.y, 0);
            else if (transform.position.x > offset)
                _transform.position = new Vector3(offset, _transform.position.y, 0);
        }

        void KeepWithinYBounds()
        {
            if (_transform.position.y > offset)
                _transform.position = new Vector3(_transform.position.x, offset, 0);
            else if (transform.position.y < -offset)
                _transform.position = new Vector3(_transform.position.x, -offset, 0);
        }

        public float Speed => speed;

        void OnTriggerEnter2D(Collider2D other) => other.GetComponent<ICollectable>()?.Collect();

        public void Kill() => GameStateEventHandler.OnPlayerWasHitByEnemy(transform);
    }
}