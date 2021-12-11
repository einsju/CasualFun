using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class ColorTween : Tween
    {
        [SerializeField] TextMeshProUGUI textToTween;
        [SerializeField] Color endColor;

        Color _originalColor;

        void Awake() => _originalColor = textToTween.color;

        protected override void DoTween() =>
            LeanTween.value(gameObject, ValueUpdated, _originalColor, endColor, duration)
                .setDelay(delay).setEase(tweenType);
                

        protected override void DoTweenLoop() =>
            LeanTween.value(gameObject, ValueUpdated, _originalColor, endColor, duration)
                .setDelay(delay).setEase(tweenType).setLoopPingPong();

        void ValueUpdated(Color color) => textToTween.color = color;
    }
}
