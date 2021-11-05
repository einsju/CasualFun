using UnityEngine;

public class Orbit_Enemy : MonoBehaviour
{
    const float Speed = 0.05f;

    void Update()
    {
        transform.position += transform.up * Speed;
    }
}
