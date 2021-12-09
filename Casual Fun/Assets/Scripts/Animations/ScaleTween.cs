using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class ScaleTween : Tween
    {
        [SerializeField] Vector3 destination = Vector3.one;

        Transform _transform;

        void Awake() => _transform = transform;

        protected override void DoTween() => _transform.LeanScale(destination, duration);

        protected override void DoTweenLoop() => _transform.LeanScale(destination, duration).setLoopPingPong();
    }
}
