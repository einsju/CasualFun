using CasualFun.Abstractions;
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
        
        void OnTriggerEnter2D(Collider2D other) => other.GetComponent<IKillable>()?.Kill();
    }
}
