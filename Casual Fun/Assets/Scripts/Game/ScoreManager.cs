using CasualFun.AtCirclesEdge.State;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        public int Score { get; private set; }

        void Awake() => GameStateEventHandler.GameStarted += ResetScore;

        public void AddScore(int score)
        {
            Score += score;
            ShowScore();
        }

        void ResetScore()
        {
            Score = 0;
            ShowScore();
        }

        void ShowScore() => scoreText.text = $"{Score}";
    }
}
