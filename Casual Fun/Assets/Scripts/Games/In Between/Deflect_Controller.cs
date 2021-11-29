using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace CasualFun.Games.InBetween
{
    public class Deflect_Controller : MonoBehaviour
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
        [SerializeField] GameManager gameManager;
        Deflect_Spawner spawner;
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
                (effectPoint.gameObject, new Vector2(250, 250), Quaternion.identity);
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
        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    Time.timeScale = 0;
                    //gameManager.soundManager.PlaySound(0);
                    Lose();
                    break;
                case "Point":
                    collision.transform.position = spawner.RandomPosition();
                    PlayEffect(collision.transform.position);
                    spawner.AddPoint();
                    //gameManager.soundManager.PlaySound(1);
                    spawner.AddEnemy();

                    break;
                case "Coins":
                    collision.gameObject.SetActive(false);
                    PlayEffect(collision.transform.position);
                    spawner.EnableCoins();
                    //gameManager.soundManager.PlaySound(1);
                    break;
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Functions

        void Lose()
        {
            this.enabled = false;
        }

        void Setup()
        {
            spawner = Deflect_Spawner.inst;

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
    }
}
