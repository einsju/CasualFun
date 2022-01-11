using CasualFun.AtCirclesEdge.Abstractions;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScorePoint : MonoBehaviour, ICollectable
    {
        SpriteRenderer _renderer;
        TextMeshPro _text;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _text = GetComponentInChildren<TextMeshPro>();
        }

        public void SetText(string value) => _text.text = value;

        public void Collect()
        {
            EventManager.OnPlayerPickedUpScorePoint(_renderer.transform.position);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
