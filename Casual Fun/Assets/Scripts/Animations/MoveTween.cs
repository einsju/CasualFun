using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class MoveTween : MonoBehaviour
    {
        [SerializeField] Vector3 startPosition;
        [SerializeField] Vector3 endPosition;
        [SerializeField] float duration;

        Transform _transform;

        void Awake() => _transform = transform;

        void OnEnable()
        {
            ResetPosition();
            DoTween();
        }
        
        void ResetPosition() => _transform.localPosition = startPosition;

        void DoTween() => _transform.LeanMoveLocal(endPosition, duration).setEaseOutBounce();
    }
}
