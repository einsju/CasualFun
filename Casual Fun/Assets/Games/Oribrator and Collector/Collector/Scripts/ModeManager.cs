using System.Collections;
using System.Collections.Generic;
using CasualFun.Games.OrbitratorAndCollector;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    Text timeScore;
    GameManager gameManager;
    bool enableMode = false;
    public static ModeManager inst;
    Image buttonImage;
    [SerializeField]
    Sprite timerMode,survivalMode;
    private void Awake()
    {
        inst = this;
        Button button = GameObject.FindGameObjectWithTag("modeButton").GetComponent<Button>();
        buttonImage = button.image;
        button.onClick.AddListener(()=>ChangeMode());
        timeScore = GameObject.FindGameObjectWithTag("timeScore").GetComponent<Text>();
        gameManager = GameManager.Inst;
        passTime = time;
    }
    void ChangeMode()
    {
        enableMode = !enableMode;
        timeScore.enabled = enableMode;
        string data = gameManager.ScoreManager.data;
        if (enableMode)
        {
            cacheTime = PlayerPrefs.GetFloat(data);
            gameManager.ScoreManager.scoreText.text = cacheTime.ToString("0.0");
            buttonImage.sprite = timerMode;
        }
        else
        {
            gameManager.ScoreManager.scoreText.text = PlayerPrefs.GetInt(data).ToString();
            buttonImage.sprite = survivalMode;
        }
        //enabled = !isActiveAndEnabled;
    }
    public void OnStart()
    {
        if (!enableMode) return;
        enabled = enableMode;

    }
    float passTime, survivalTime, cacheTime;
    [SerializeField]
    float time;
    void Update()
    {
        passTime -= Time.deltaTime;
        survivalTime += Time.deltaTime;
        gameManager.ScoreManager.scoreText.text = survivalTime.ToString("0.0");
        timeScore.text = passTime.ToString("0.0");
        if (passTime <= 0)
        {
            passTime = time;
            Deflect_Spawner.inst.AddEnemy();
        }
    }
    public void ResetTimer()
    {
        passTime = time;
    }
    public void Reset()
    {
        enabled = false;
        if (enableMode)
        {
            Text scoreText = gameManager.ScoreManager.scoreText;
            if (survivalTime > cacheTime)
            {
                cacheTime = survivalTime;
                string data = gameManager.ScoreManager.data;
                PlayerPrefs.SetFloat(data, survivalTime);
                scoreText.text = survivalTime.ToString("0.0");
            }
            else
            {
                scoreText.text =
                cacheTime.ToString("0.0");
            }
            timeScore.text = 0.ToString("0.0");
        }
        else
        {
            gameManager.ScoreManager.SaveGameScore();
        }
    }
}
