using CasualFun.Abstractions;
using CasualFun.State;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class ScorePoint : MonoBehaviour, ICollectable
    {
        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();

        void Start() => TweenScale();

        void TweenScale()
        {
            var localScale = transform.localScale;
            
            LeanTween.scale(gameObject,
                    new Vector3(localScale.x - 0.005f, localScale.y - 0.005f, localScale.z),
                    0.3f)
                .setLoopPingPong();
        }

        public void Collect()
        {
            GameStateEventHandler.OnPlayerPickedUpCollectable(_renderer.transform.position);
            Reposition();
        }
        
        void Reposition() => transform.parent.eulerAngles = RandomPointInCircle;

        static Vector3 RandomPointInCircle => new Vector3(0, 0, Random.Range(-360, 360));
    }
}
