using CasualFun.AtCirclesEdge.State;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        int _score;

        void Awake()
        {
            GameStateEventHandler.GameStarted += ResetScore;
            //GameStateEventHandler.LevelCompleted += () => PlayerDataInstance.PlayerData.SetHighScore(_score);
        }

        public void AddScore(int score)
        {
            _score += score;
            ShowScore();
        }

        void ResetScore()
        {
            _score = 0;
            ShowScore();
        }

        void ShowScore() => scoreText.text = $"{_score}";
    }
}
