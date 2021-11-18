using System.Collections;
using CasualFun.Games.OrbitratorAndCollector;
using UnityEngine;

namespace CasualFun.Games.Orbitrator
{
    public class OrbitManager : Player
    {
        [SerializeField] Sprite[] pointCollectableSprites;
        [SerializeField] GameObject explosion;
        [SerializeField] GameObject collectPrefab;
        
        public float speed = -100;
        SpriteRenderer _playerSprite;
        GameManager _gameManager;
        AudioPlayer _audioPlayer;

        void Awake()
        {
            _playerSprite = GetComponent<SpriteRenderer>();
            _audioPlayer = FindObjectOfType<AudioPlayer>();
            CreatePool();
        }

        void Start() => _gameManager = GameManager.Inst;

        void OnEnable() => StartCoroutine(Spawner());

        void Update()
        {
            transform.parent.transform.Rotate(0, 0, speed * Time.unscaledDeltaTime);
            if (Input.GetButtonDown("Fire1")) Direction();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag($"Point"))
            {
                Instantiate(collectPrefab, collision.transform.position, Quaternion.identity);
                RandomPointPosition();
                if (Time.timeScale < 1.8f)
                {
                    Time.timeScale += 0.05f;
                }
                _gameManager.ScoreManager.AddScore();
                _gameManager.coins += 1;
                _audioPlayer.OnItemCollected();
            }

            if (!collision.CompareTag($"Enemy")) return;
            enabled = false;
            StopAllCoroutines();
            _audioPlayer.OnGameOver();
            _gameManager.Lose();
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            _gameManager.ScoreManager.SaveGameScore();
        }

        void Direction()
        {
            speed = speed * -1;
            _playerSprite.flipX = speed < 0;
        }

        public
            GameObject enemy, point;

        GameObject[] _enemies;

        bool _canSpawn = true;

        IEnumerator Spawner()
        {
            while (_canSpawn)
            {
                var e = GetEnemy();
                e.transform.position = Vector2.zero;
                e.transform.rotation = transform.rotation;
                if (speed < 0)
                {
                    //Left
                    e.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, -90));
                }
                else
                {
                    //Right
                    e.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 90));
                }

                _canSpawn = true;
                yield return new WaitForSeconds(0.3f);
            }
        }

        void RandomPointPosition()
        {
            float random = Random.Range(-360, 360);
            point.transform.eulerAngles = new Vector3(0, 0, random);
            RandomizePointCollectableSprite();
        }

        void RandomizePointCollectableSprite()
        {
            var randomIndex = Random.Range(0, pointCollectableSprites.Length);
            point.GetComponentInChildren<SpriteRenderer>().sprite = pointCollectableSprites[randomIndex];
        }

        int _index;

        GameObject GetEnemy()
        {
            _index++;
            if (_index >= _enemies.Length) _index = 0;
            return _enemies[_index];
        }

        void CreatePool()
        {
            const int max = 10;
            _enemies = new GameObject[max];
            RandomPointPosition();
            for (var i = 0; i < max; i++)
            {
                _enemies[i] = Instantiate(enemy, Vector3.one * 100, Quaternion.identity);
            }
        }

        public override void Enable(bool enable) => enabled = enable;

        public override void Reset() => transform.parent.rotation = Quaternion.identity;
    }
}