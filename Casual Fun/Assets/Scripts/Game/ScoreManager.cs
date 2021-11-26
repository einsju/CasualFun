using TMPro;
using UnityEngine;

namespace CasualFun.Game
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        int _score;

        void Awake() => ShowScore();

        public void AddScore(int score)
        {
            _score += score;
            ShowScore();
        }

        public void ResetScore()
        {
            _score = 0;
            ShowScore();
        }

        void ShowScore() => scoreText.text = $"{_score}";
    }
}
