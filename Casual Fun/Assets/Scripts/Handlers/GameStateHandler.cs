using CasualFun.Handlers;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public void StartGame() => GameStateEventHandler.OnGameStarted();
    public void EndGame() => GameStateEventHandler.OnGameOver();
}
