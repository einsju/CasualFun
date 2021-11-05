using System.Collections;
using System.Collections.Generic;
using CasualFun.Games.OrbitratorAndCollector;
using UnityEngine;

using UnityEngine.UI;

public class Deflect_Controller : Player
{
    #region Variables
    public float speed = 2200;
    int offset = 95;
    float x;
    Vector3 direction;
    public ParticleSystem effectPoint;
    Collider playerCollider;
    SpriteRenderer playerSprite;
    Rigidbody rb;
    GameManager gameManager;
    Deflect_Spawner spawner;
    ModeManager modeManager;
    public static Deflect_Controller inst;
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Unity Callbacks
    private void Awake()
    {
        inst = this;
        //Setup
        rb = GetComponent<Rigidbody>();
        x = Screen.width;
        //GetComponent
        playerCollider = GetComponent<Collider>();
        playerSprite = GetComponent<SpriteRenderer>();
        //effect
        GameObject obj = Instantiate
            (effectPoint.gameObject,new Vector2(250,250),Quaternion.identity);
        effectPoint = obj.GetComponent<ParticleSystem>();
        Invoke("Setup", Time.deltaTime);
    }
    private void OnEnable()
    {
        playerCollider.enabled = true;   
        SetAlpha(1);
    }
    private void OnDisable()
    {
        playerCollider.enabled = false;
        rb.velocity = Vector3.zero;
        SetAlpha(0.5f);
        PlayerPrefs.SetFloat("Speed", speed);
    }
#if UNITY_EDITOR
    Vector2 lastPosition;
    private void LateUpdate()
    {
        lastPosition = Input.mousePosition;
    }
#endif
    void Update()
    {
        //GetDirection
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            direction = touch.deltaPosition / x;
            transform.position += Vector3.Lerp(Vector3.zero, direction * speed, 0.1f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = lastPosition - (Vector2)Input.mousePosition;
            direction = mouseDelta / x;
            transform.position += Vector3.Lerp(Vector3.zero, -direction * speed, 0.1f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
#endif
        //Keep player inside bounds
        if (transform.position.y > offset)
        {
            transform.position = new Vector3(transform.position.x, offset, 0);
        }
        else if (transform.position.y < -offset)
        {
            transform.position = new Vector3(transform.position.x, -offset, 0);
        }
        if (transform.position.x < -offset)
        {
            transform.position = new Vector3(-offset, transform.position.y, 0);
        }
        else if (transform.position.x > offset)
        {
            transform.position = new Vector3(offset, transform.position.y, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Time.timeScale = 0;
                gameManager.soundManager.PlaySound(0);
                Lose();
                break;
            case "Point":
                collision.transform.position = spawner.RandomPosition();
                PlayEffect(collision.transform.position);
                spawner.AddPoint();
                gameManager.soundManager.PlaySound(1);
                if (modeManager.isActiveAndEnabled)
                {
                    modeManager.ResetTimer();
                }
                else
                {
                    spawner.AddEnemy();
                }
                break;
            case "Coins":
                collision.gameObject.SetActive(false);
                PlayEffect(collision.transform.position);
                spawner.EnableCoins();
                gameManager.soundManager.PlaySound(1);
                break;
        }
    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Functions
    void Lose()
    {
        this.enabled = false;
        gameManager.Lose();
    }
    void Setup()
    {
        gameManager = GameManager.Inst;
        spawner = Deflect_Spawner.inst;
        modeManager = ModeManager.inst;

    }
    public void SetAlpha(float a)
    {
        Color tmp = playerSprite.color;
        tmp.a = a;
        playerSprite.color = tmp;
    }
    void PlayEffect(Vector2 Pos)
    {
        effectPoint.transform.position = Pos;
        effectPoint.Play();
    }
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Virtual
    /*public override void Enable(bool enabled)
    {
        this.enabled = enabled;
        modeManager.OnStart();
        if (modeManager.isActiveAndEnabled) return;
        gameManager.ScoreManager.scoreText.text = 0.ToString();
    }
    public override void Reset()
    {
        this.transform.position = Vector2.zero;
        spawner.OnReset();
        modeManager.Reset();
    }*/
    #endregion
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
}
