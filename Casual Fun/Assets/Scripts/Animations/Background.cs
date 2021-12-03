using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public class Background : MonoBehaviour
    {
        [SerializeField] float duration = 0.4f;
        
        float DestinationX => transform.localPosition.x > 0 ? -400f : 400f;
        Vector2 Destination => new Vector2(DestinationX, transform.localPosition.y);

        void OnEnable() => EventManager.ScreenOpened += ScreenOpened;
        void OnDisable() => EventManager.ScreenOpened -= ScreenOpened;

        void ScreenOpened() => transform.LeanMoveLocalX(Destination.x, duration).setEaseOutCirc();
    }
}
