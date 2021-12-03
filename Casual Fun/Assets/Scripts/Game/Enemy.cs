using CasualFun.AtCirclesEdge.Abstractions;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class Enemy : MonoBehaviour
    {
        const float Speed = 0.2f;
        Transform _transform;

        void Awake() => _transform = transform;

        void Update() => Move();
        
        void Move() => _transform.position += _transform.up * Speed;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<IKillable>()?.Kill();
            gameObject.SetActive(false);
        }
    }
}
