using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class GameManager : MonoBehaviour
    {
        [Header("Settings")] public int coinsToEarn = 10;
        [FormerlySerializedAs("CamOffset")] public float camOffset = 11;
        [HideInInspector] public int coins;
        [Header("References")] public ScoreManager ScoreManager;
        [HideInInspector] public SoundManager soundManager;

        readonly Store _store;

        Player _player;

        public static GameManager Inst;

        public GameManager(Store store)
        {
            _store = store;
        }

        float GetBounds()
        {
            var bounds = _player.GetComponent<SpriteRenderer>();
            return bounds.bounds.size.x * Screen.height / Screen.width * camOffset;
        }

        void Awake()
        {
            Inst = this;
        }

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            //setup score
            var scoreObject = GameObject.FindGameObjectWithTag("ScoreText");
            var scoreText = scoreObject.GetComponent<Text>();
            var gameName = SceneManager.GetActiveScene().name;
            ScoreManager = new ScoreManager(scoreText, gameName);
            GetInstance();
            // if (_store.player == null)
            // {
            //     _store.player = _player.GetComponent<SpriteRenderer>();
            // }

            ScoreManager.LoadSaveGameScore();
            CamSetup();
        }

        void GetInstance()
        {
            soundManager = SoundManager.Inst;
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void CamSetup()
        {
            if (Camera.main is { }) Camera.main.orthographicSize = GetBounds();
        }

        public void BeginPlay()
        {
            _player.Enable(true);
        }

        public void ResetGame()
        {
            ResetValues();
            Time.timeScale = 1;
        }

        void ResetValues()
        {
            ScoreManager.currentPoints = 0;
            coins = 0;
            _player.Reset();
            _store.RandomizePlayer();
        }

        public void Lose()
        {
            _store.SaveCoins(coins);
        }

        public void AddCoins()
        {
            coins += coinsToEarn;
        }

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
