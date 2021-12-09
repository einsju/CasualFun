using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class ColorTween : Tween
    {
        [SerializeField] TextMeshProUGUI textToTween;
        [SerializeField] Color destination;

        Color _originalColor;

        void Awake() => _originalColor = textToTween.color;

        protected override void DoTween() =>
            LeanTween.value(gameObject, UpdateValueCallback, _originalColor, destination, 1f)
                .setDelay(duration);

        protected override void DoTweenLoop() =>
            LeanTween.value(gameObject, UpdateValueCallback, _originalColor, destination, 1f)
                .setDelay(duration)
                .setLoopPingPong();

        void UpdateValueCallback(Color color) => textToTween.color = color;
    }
}
