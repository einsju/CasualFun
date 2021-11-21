using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class OrbitManager : MonoBehaviour
    {
        [SerializeField] GameObject explosionPrefab;
        
        AudioPlayer _audioPlayer;

        void Awake()
        {
            _audioPlayer = FindObjectOfType<AudioPlayer>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag($"Point"))
            {
                collectable.Collected();
                if (Time.timeScale < 1.8f)
                {
                    Time.timeScale += 0.05f;
                }
                _audioPlayer.OnItemCollected();
            }

            if (!collision.CompareTag($"Enemy")) return;
            enabled = false;
            _audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
            //Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }

        public GameObject enemy;
        public Collectable collectable;
    }
}