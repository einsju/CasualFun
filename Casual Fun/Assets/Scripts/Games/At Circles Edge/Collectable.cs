using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class Collectable : MonoBehaviour, ICollectable
    {
        [SerializeField] Sprite[] collectableSprites;

        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();
        
        public void Collect()
        {
            GameStateEventHandler.OnPlayerPickedUpCollectable(_renderer.transform.position);
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
