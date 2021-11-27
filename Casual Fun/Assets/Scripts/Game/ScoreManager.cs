using TMPro;
using UnityEngine;

namespace CasualFun.Game
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        public int Score { get; private set; }

        void Awake() => ShowScore();

        public void AddScore(int score)
        {
            Score += score;
            ShowScore();
        }

        public void ResetScore()
        {
            Score = 0;
            ShowScore();
        }

        void ShowScore() => scoreText.text = $"{Score}";
    }
}
