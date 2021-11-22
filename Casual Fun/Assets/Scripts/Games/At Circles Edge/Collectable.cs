using CasualFun.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] Sprite[] collectableSprites;

        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!HasCollidedWithPlayer(other.tag)) return;
            GameManager.Instance.PlayerPickedUpCollectable(_renderer.transform.position);
            Reposition();
        }

        static bool HasCollidedWithPlayer(string tagName) => tagName == TagNames.Player;
        
        void Reposition()
        {
            transform.parent.eulerAngles = RandomPointInCircle;
            SelectRandomSprite();
        }
        
        static Vector3 RandomPointInCircle => new Vector3(0, 0, Random.Range(-360, 360));
        
        void SelectRandomSprite() => _renderer.sprite = RandomSprite;

        Sprite RandomSprite => collectableSprites[Random.Range(0, collectableSprites.Length)];
    }
}
