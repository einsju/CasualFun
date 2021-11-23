using CasualFun.Handlers;
using CasualFun.Utilities;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Enemy : MonoBehaviour
    {
        const float Speed = 0.15f;
        Transform _transform;

        void Awake() => _transform = transform;

        void Update() => Move();
        
        void Move() => _transform.position += _transform.up * Speed;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!HasCollidedWithPlayer(other.tag)) return;
            GameStateEventHandler.OnPlayerWasHitByEnemy(other.transform);
        }

        static bool HasCollidedWithPlayer(string tagName) => tagName == TagNames.Player;
    }
}
