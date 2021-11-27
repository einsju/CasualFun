using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;
using Random = UnityEngine.Random;

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
        GameStateEventHandler.OnPlayerPickedUpCoin(_renderer.transform.position);
        _renderer.enabled = false;
        Reposition();
        HandleCoinVisibility();
    }
         
    void Reposition() => transform.parent.eulerAngles = RandomPointInCircle;

    static Vector3 RandomPointInCircle => new Vector3(0, 0, Random.Range(-360, 360));
}
