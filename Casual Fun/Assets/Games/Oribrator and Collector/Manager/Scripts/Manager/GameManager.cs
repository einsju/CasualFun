using CasualFun.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class GameManager : MonoBehaviour
    {
        [Header("Settings")] public int coinsToEarn = 10;
        [FormerlySerializedAs("CamOffset")] public float camOffset = 11;
        [HideInInspector] public int coins;
        [Header("References")] public ScoreManager ScoreManager;
        [SerializeField] Player player;

        // readonly Store _store;

        public static GameManager Inst;

        // public GameManager(Store store) => _store = store;

        float GetBounds()
        {
            var bounds = player.GetComponent<SpriteRenderer>();
            return bounds.bounds.size.x * Screen.height / Screen.width * camOffset;
        }

        void Awake() => Inst = this;

        void Start() => Initialize();

        void Initialize()
        {
            //setup score
            var scoreObject = GameObject.FindGameObjectWithTag("ScoreText");
            var scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            var gameName = SceneManager.GetActiveScene().name;
            ScoreManager = new ScoreManager(scoreText, gameName);
            // if (_store.player == null)
            // {
            //     _store.player = _player.GetComponent<SpriteRenderer>();
            // }

            ScoreManager.LoadSaveGameScore();
            CamSetup();
        }

        void CamSetup()
        {
            if (Camera.main is { }) Camera.main.orthographicSize = GetBounds();
        }

        public void BeginPlay()
        {
            Time.timeScale = 1;
            player.Enable(true);
            GameStateEventHandler.OnGameStarted();
        }
        
        public void ResetGame()
        {
            ResetValues();
            //Time.timeScale = 1;
        }

        void ResetValues()
        {
            ScoreManager.CurrentPoints = 0;
            coins = 0;
            player.Reset();
            // _store.RandomizePlayer();
        }

        public void Lose()
        {
            GameStateEventHandler.OnGameOver();
            ResetValues();
            // _store.SaveCoins(coins);
        }

        public void AddCoins() => coins += coinsToEarn;

        public void ChangeScene(string scene) => SceneManager.LoadScene(scene);
    }
}
