using CasualFun.AtCirclesEdge.Abstractions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScorePoint : MonoBehaviour, ICollectable
    {
        [SerializeField] float increaseTweenFactor = 0.01f;
        
        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();

        void Start() => TweenScale();

        void TweenScale()
        {
            var localScale = transform.localScale;
            
            LeanTween.scale(gameObject,
                    new Vector3(localScale.x + increaseTweenFactor, localScale.y + increaseTweenFactor, localScale.z),
                    0.3f)
                .setLoopPingPong();
        }

        public void Collect()
        {
            GameManager.Instance.PlayerPickedUpCollectable(_renderer.transform.position);
            Reposition();
        }
        
        void Reposition() => transform.parent.eulerAngles = RandomPointInCircle;

        static Vector3 RandomPointInCircle => new Vector3(0, 0, Random.Range(-360, 360));
    }
}
