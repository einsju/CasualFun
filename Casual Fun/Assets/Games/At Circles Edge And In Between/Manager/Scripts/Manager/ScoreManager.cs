using UnityEngine;
using TMPro;

namespace CasualFun.Games.AtCirclesEdgeAndInBetween
{
    public class ScoreManager
    {
        public float Time = 1;
        public int CurrentPoints;
        public readonly string Data = "HighScorePointsData";
        public readonly TextMeshProUGUI ScoreText;

        int _score;

        public ScoreManager(TextMeshProUGUI score, string gameName)
        {
            ScoreText = score;
            Data += gameName;
        }

        public void AddScore()
        {
            CurrentPoints++;
            ScoreText.text = CurrentPoints.ToString();
        }

        public void SaveGameScore()
        {
            if (CurrentPoints > _score)
            {
                _score = CurrentPoints;
                PlayerPrefs.SetInt(Data, CurrentPoints);
                ScoreText.text = CurrentPoints.ToString();
            }
            else
            {
                ScoreText.text = _score.ToString();
            }
        }

        public void LoadSaveGameScore() => ScoreText.text = (_score = PlayerPrefs.GetInt(Data)).ToString();
    }
}
