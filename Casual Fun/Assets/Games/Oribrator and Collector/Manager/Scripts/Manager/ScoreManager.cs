using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class ScoreManager
    {
        public float time = 1;
        public int currentPoints;
        public string data = "HigthScorePointsData";
        public Text scoreText;

        int score;

        //Constructor
        public ScoreManager(Text score, string gameName)
        {
            scoreText = score;
            data = data + gameName;
        }

        public void AddScore()
        {
            currentPoints++;
            scoreText.text = currentPoints.ToString();
        }

        public void SaveGameScore()
        {
            if (currentPoints > score)
            {
                score = currentPoints;
                PlayerPrefs.SetInt(data, currentPoints);
                scoreText.text = currentPoints.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
        }

        public void LoadSaveGameScore()
        {
            scoreText.text = (score = PlayerPrefs.GetInt(data)).ToString();
        }
    }
}
