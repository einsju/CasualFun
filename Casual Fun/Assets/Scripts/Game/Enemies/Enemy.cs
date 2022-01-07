using CasualFun.AtCirclesEdge.Abstractions;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Enemies
{
    public class Enemy : MonoBehaviour
    {   
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<IKillable>()?.Kill();
            gameObject.SetActive(false);
        }
    }
}
