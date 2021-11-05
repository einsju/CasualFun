using UnityEngine;
using UnityEngine.EventSystems;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] float percentThreshold = 0.5f;

        Store _store;
        void Start() => _store = transform.GetComponentInParent<Store>();
        public void OnBeginDrag(PointerEventData data) {}
        public void OnDrag(PointerEventData data) {}
        public void OnEndDrag(PointerEventData data)
        {
            var percentage = (data.pressPosition.x - data.position.x) / Screen.width;
            if (Mathf.Abs(percentage) >= percentThreshold)
                _store.SwipeButtons((int) percentage);
        }
    }
}
