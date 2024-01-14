using System;
using UnityEngine;

namespace AnotherWorldProject.UnitSystem
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
        public Action onAnimationStart;
        public Action onEndAnimation;

        public void SetBool(string AnimationName, bool runAnimation)
        {
            animator.SetBool(AnimationName, runAnimation);
        }
        public void TriggerAnimationEvent(string AnimationName)
        {
            animator.SetTrigger(AnimationName);
        }
        public void StartAnimation()
        {
            onAnimationStart?.Invoke();
        }
        public void EndAnimation()
        {
            onEndAnimation?.Invoke();
        }
    }
}

