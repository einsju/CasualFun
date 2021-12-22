using CasualFun.AtCirclesEdge.Abstractions;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class Enemy : MonoBehaviour
    {
        const float Speed = 4f;
        
        Transform _transform;

        void Awake() => _transform = transform;

        void Update()
        {
            if (!GameStateHandler.GameIsRunning) return;
            Move();
        }

        void Move() => _transform.position += _transform.up * Speed * Time.deltaTime;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<IKillable>()?.Kill();
            gameObject.SetActive(false);
        }
    }
}
