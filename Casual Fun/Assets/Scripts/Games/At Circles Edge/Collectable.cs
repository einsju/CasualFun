using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] Sprite[] collectableSprites;
        [SerializeField] GameObject collectedEffect;

        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();

        public void Collected()
        {
            Instantiate(collectedEffect, _renderer.transform.position, Quaternion.identity);
            Reposition();
        }
        
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
