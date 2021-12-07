using CasualFun.AtCirclesEdge.Abstractions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.AtCirclesEdge.Game
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] float spawnRate = 5f;

        SpriteRenderer _renderer;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.enabled = false;
        }

        void Start()
        {
            Reposition();
            HandleCoinVisibility();
        }

        void HandleCoinVisibility() => Invoke(nameof(ShowCoin), spawnRate);

        void ShowCoin()
        {
            if (_renderer.enabled) return;
            _renderer.enabled = true;
        }

        public void Collect()
        {
            if (!CanCollect) return;
            GameManager.Instance.PlayerPickedUpCoin(_renderer.transform.position);
            _renderer.enabled = false;
            Reposition();
            HandleCoinVisibility();
        }

        bool CanCollect => _renderer.isVisible;

        void Reposition() => transform.parent.eulerAngles = RandomPointInCircle;

        static Vector3 RandomPointInCircle => new Vector3(0, 0, Random.Range(-360, 360));
    }
}