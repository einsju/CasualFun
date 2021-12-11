using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Animations
{
    public abstract class Tween : MonoBehaviour
    {
        [SerializeField] protected bool loop = true;
        [Range(0, 5)][SerializeField] protected float delay;
        [Range(0, 5)][SerializeField] protected float duration = 1f;
        [SerializeField] protected LeanTweenType tweenType = LeanTweenType.notUsed;

        protected Transform Transform;

        void Awake() => Transform = transform;
        
        void Start() => PrepareNonLoopAnimationsToRun();

        void OnEnable()
        {
            if (!loop)
            {
                DoTween();
                return;
            }
            
            DoTweenLoop();
            
        }

        void PrepareNonLoopAnimationsToRun()
        {
            if (loop) return;
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        protected abstract void DoTween();
        protected abstract void DoTweenLoop();
    }
}