using System;
using CasualFun.AtCirclesEdge.Player;
using UnityEngine;

public class PlayerDataInstance : MonoBehaviour
{
    public static event Action PlayerDataInstanceUpdated;
    public static PlayerData PlayerData { get; private set; }

    void Awake()
    {
        PlayerDataLoader.PlayerDataLoaded += PlayerDataUpdated;
        PlayerData.PlayerDataUpdated += PlayerDataUpdated;
    }

    void OnDestroy()
    {
        PlayerDataLoader.PlayerDataLoaded -= PlayerDataUpdated;
        PlayerData.PlayerDataUpdated -= PlayerDataUpdated;
    }

    static void PlayerDataUpdated(PlayerData data)
    {
        PlayerData = data;
        PlayerDataInstanceUpdated?.Invoke();
    }
}
