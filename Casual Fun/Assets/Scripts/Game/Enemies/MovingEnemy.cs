using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Enemies
{
    public class MovingEnemy : Enemy
    {
        [SerializeField] float speed = 4f;
        
        Transform _transform;

        void Awake() => _transform = transform;

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            Move();
        }

        void Move() => _transform.position += _transform.up * speed * Time.deltaTime;
    }
}
