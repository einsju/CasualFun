using System.Collections;
using CasualFun.Games.OrbitratorAndCollector;
using UnityEngine;

public class Orbit_Manager : Player
{
    public float speed = -100;
    SpriteRenderer _playerSprite;
    GameManager _gameManager;

    public static Orbit_Manager Inst;

    void Awake()
    {
        Inst = this;
        _playerSprite = GetComponent<SpriteRenderer>();
        CreatePool();
    }

    void Start()
    {
        _gameManager = GameManager.Inst;
    }

    void OnEnable()
    {
        StartCoroutine(Spawner());
    }
    void Update()
    {
       transform.parent.transform.Rotate(0, 0, speed * Time.unscaledDeltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            Direction();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag($"Point"))
        {
            RandomPointPosition();
            if (Time.timeScale < 1.8f)
            {
                Time.timeScale += 0.05f;
            }
            _gameManager.ScoreManager.AddScore();
            _gameManager.coins += 1;
            _gameManager.soundManager.PlaySound(0);
        }

        if (!collision.CompareTag($"Enemy")) return;
        Time.timeScale = 0;
        enabled = false;
        StopAllCoroutines();
        _gameManager.Lose();
        _gameManager.ScoreManager.SaveGameScore();
        _gameManager.soundManager.PlaySound(1);
    }

    void Direction()
    {
        speed = speed * -1;
        _playerSprite.flipX = speed < 0;
    }

    #region Spawner
    //Spawn
    public
    GameObject enemy,point;
    GameObject[] _enemies;

    IEnumerator Spawner()
    {
        while (true)
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
            yield return new WaitForSeconds(0.3f);
        }
    }
    
    void RandomPointPosition()
    {
        float random = Random.Range(-360,360);
        point.transform.eulerAngles = new Vector3(0,0,random);
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
        var max = 10;
        _enemies = new GameObject[max];
        RandomPointPosition();
        for(var i = 0; i < max; i++)
        {
            _enemies[i] = Instantiate(enemy, Vector3.one*100, Quaternion.identity);
        }
    }
    #endregion

    #region Virtual
    public void Enable(bool enabled)
    {
        this.enabled = enabled;
    }
    public void Reset()
    {
        transform.parent.rotation = Quaternion.identity;
    }
    #endregion
}