using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class ScaleTween : Tween
    {
        [SerializeField] Vector3 startScale = Vector3.one;
        [SerializeField] Vector3 endScale = Vector3.one;

        void OnDisable() => Transform.localScale = startScale;

        protected override void DoTween() =>
            Transform.LeanScale(endScale, duration).setDelay(delay).setEase(tweenType);

        protected override void DoTweenLoop() =>
            Transform.LeanScale(endScale, duration).setDelay(delay).setEase(tweenType).setLoopPingPong();
    }
}
