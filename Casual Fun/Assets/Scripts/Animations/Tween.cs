using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public abstract class Tween : MonoBehaviour
    {
        [SerializeField] protected float duration;
        [SerializeField] protected bool loop = true;

        void Start()
        {
            if (!loop)
            {
                DoTween();
                return;
            }
            
            DoTweenLoop();
            
        }

        protected abstract void DoTween();
        protected abstract void DoTweenLoop();
    }
}