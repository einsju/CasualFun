using CasualFun.AtCirclesEdge.Abstractions;
using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] float spawnRate = 5f;
        [SerializeField] float timeToCollect = 3f;

        SpriteRenderer _renderer;
        float _timer;

        bool CoinIsVisible => _renderer.isVisible;

        void ShowCoin() => _renderer.enabled = true;
        
        void HideCoin()
        {
            _timer = 0;
            _renderer.enabled = false;
        }

        void Awake() => _renderer = GetComponent<SpriteRenderer>();

        void Start() => HideCoin();

        void OnDisable() => Reposition();

        void Reposition() => transform.parent.MoveToRandomPositionInCircle();

        void Update()
        {
            if (!GameManager.Instance.GameIsRunning) return;
            HandleCoinVisibility();
        }

        void HandleCoinVisibility()
        {
            _timer += Time.deltaTime;
            ShowCoinIfCriteriaIsMet();
            HideCoinIfCriteriaIsMet();
        }

        void ShowCoinIfCriteriaIsMet()
        {
            if (!(_timer >= spawnRate) || CoinIsVisible) return;
            ShowCoin();
            _timer = 0;
        }

        void HideCoinIfCriteriaIsMet()
        {
            if (!(_timer >= timeToCollect) || !CoinIsVisible) return;
            HideCoin();
        }

        public void Collect()
        {
            if (!CanCollect) return;
            GameManager.Instance.PlayerPickedUpCoin(_renderer.transform.position);
            HideCoin();
        }

        bool CanCollect => CoinIsVisible;
    }
}
