using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class MoveTween : Tween
    {
        [SerializeField] Vector3 startPosition;
        [SerializeField] Vector3 endPosition;

        void OnDisable() => Transform.localPosition = startPosition;

        protected override void DoTween() =>
            Transform.LeanMoveLocal(endPosition, duration).setDelay(delay).setEase(tweenType);
        
        protected override void DoTweenLoop() =>
            Transform.LeanMoveLocal(endPosition, duration).setDelay(delay).setEase(tweenType).setLoopPingPong();
    }
}
