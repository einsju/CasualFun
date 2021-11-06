using UnityEngine;

namespace CasualFun.Games.Orbitrator
{
    public class OrbitEnemy : MonoBehaviour
    {
        const float Speed = 0.05f;
        Transform _transform;

        void Awake() => _transform = transform;

        void Update() => _transform.position += _transform.up * Speed;
    }
}
