using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Enemy : MonoBehaviour, ICollidable
    {
        const float Speed = 0.15f;
        Transform _transform;

        void Awake() => _transform = transform;

        void Update() => Move();
        
        void Move() => _transform.position += _transform.up * Speed;

        public void Collide(GameObject other) => GameStateEventHandler.OnPlayerWasHitByEnemy(other.transform);
    }
}
