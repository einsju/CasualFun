using System.Collections;
using UnityEngine;

namespace CasualFun.Games.InBetween
{
    public class Deflect_Spawner : MonoBehaviour
    {
        //Spawn
        [HideInInspector] public
            bool
            spawnCoin = true;

        public bool spawnOnInit = true;

        [SerializeField] GameObject[]
            objects = new GameObject[3];

        float
            boundary;

        int
            indexEnemy = 0,
            indexCoins = 0,
            spawnIndexCache,
            limitPoint = 16,
            spawnCoinCache;

        [SerializeField] int
            spawnIndex = 4,
            initialSpawn = 3,
            spawnOffset = -12,
            spawnMinArea = 20,
            spawnCoinAfter = 5,
            spawncoinOffset;

        [SerializeField] GameManager gameManager;

        public static Deflect_Spawner inst;

        int GetRandom()
        {
            return Random.Range
            (spawnCoinAfter - spawncoinOffset,
                spawnCoinAfter + spawncoinOffset);
        }

        void Awake()
        {
            inst = this;
            spawnIndexCache = spawnIndex;
        }

        void Start()
        {
            Setup();
        }

        public void Setup()
        {
            SpriteRenderer bounds = GameObject.Find("Bounds").GetComponent<SpriteRenderer>();
            boundary = bounds.bounds.extents.x + spawnOffset;
            boundary += spawnOffset;
            if (!spawnOnInit) return;
            StartCoroutine(BeginSpawn());
        }

        IEnumerator BeginSpawn()
        {
            //Enemy
            for (int i = 0; i < initialSpawn; i++)
            {
                Instantiate(objects[0], RandomInitPosition(), Quaternion.identity);
                yield return new WaitForEndOfFrame();
            }

            //Point
            objects[1] =
                Instantiate(objects[1], RandomInitPosition(), Quaternion.identity);
            //Coins
            spawnCoinCache = GetRandom();
            objects[2] =
                Instantiate(objects[2], RandomInitPosition(), Quaternion.identity);
        }

        public void AddEnemy()
        {
            indexEnemy++;
            if (indexEnemy == spawnIndex)
            {
                Spawn(0);
                if (spawnIndex < limitPoint)
                {
                    spawnIndex += spawnIndexCache;
                }
            }
        }

        public void EnableCoins()
        {
            //gameManager.AddCoins();
            spawnCoinCache = GetRandom();
            spawnCoin = true;
        }

        void AddCoin()
        {
            objects[2].transform.position = RandomPosition();
            objects[2].SetActive(true);
            spawnCoin = false;
            indexCoins = 0;
        }

        public void AddPoint()
        {
            //gameManager.ScoreManager.AddScore();
            if (spawnCoin == true)
            {
                indexCoins++;
                if (indexCoins >= spawnCoinCache)
                {
                    AddCoin();
                }
            }
        }

        public GameObject Spawn(int i)
        {

            return Instantiate(objects[i], RandomPosition(), Quaternion.identity);
        }

        public Vector2 RandomInitPosition()
        {
            bool side = (Random.value < 0.5);
            float
                RandomX,
                RandomY;
            if (side)
            {
                RandomX = Random.Range(spawnMinArea, boundary);
                RandomY = Random.Range(spawnMinArea, boundary);
            }
            else
            {
                RandomX = Random.Range(-spawnMinArea, -boundary);
                RandomY = Random.Range(-spawnMinArea, -boundary);
            }

            Vector3 pos = new Vector3(RandomX, RandomY, 0);
            return pos;
        }

        public Vector2 RandomPosition()
        {
            float RandomX = Random.Range(-spawnMinArea, -boundary);
            float RandomY = Random.Range(-spawnMinArea, -boundary);
            Vector3 pos = new Vector3(RandomX, RandomY, 0);
            return pos;
        }

        public void OnReset()
        {
            spawnCoin = true;
            indexEnemy = 0;
            spawnIndex = spawnIndexCache;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length > initialSpawn)
            {
                for (int n = 3; n < enemys.Length; n++)
                {
                    Destroy(enemys[n]);
                }
            }
        }

    }
}
