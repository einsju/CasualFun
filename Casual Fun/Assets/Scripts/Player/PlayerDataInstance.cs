using System;
using CasualFun.AtCirclesEdge.Player;
using UnityEngine;

public class PlayerDataInstance : MonoBehaviour
{
    public static PlayerDataInstance Instance;
    
    public static event Action PlayerDataInstanceUpdated;
    
    public PlayerData PlayerData { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        PlayerDataLoader.PlayerDataLoaded += PlayerDataUpdated;
        PlayerData.PlayerDataUpdated += PlayerDataUpdated;
    }

    void OnDestroy()
    {
        PlayerDataLoader.PlayerDataLoaded -= PlayerDataUpdated;
        PlayerData.PlayerDataUpdated -= PlayerDataUpdated;
    }

    void PlayerDataUpdated(PlayerData data)
    {
        PlayerData = data;
        PlayerDataInstanceUpdated?.Invoke();
    }
}
