using CasualFun.AtCirclesEdge.Abstractions;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScorePoint : MonoBehaviour, ICollectable
    {
        static int points = 1;
        
        SpriteRenderer _renderer;
        TextMeshPro _text;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _text = GetComponentInChildren<TextMeshPro>();
        }

        public void Collect()
        {
            GameManager.Instance.PlayerPickedUpCollectable(_renderer.transform.position);
            _text.text = $"{++points}";
            Reposition();
        }

        void Reposition() => transform.parent.MoveToRandomPositionInCircle();
    }
}
