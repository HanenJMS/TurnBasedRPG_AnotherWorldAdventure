using System;
using UnityEngine;

namespace AnotherWorldProject.UnitSystem
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
        public Action onAnimationStart;
        public Action onAnimationEnd;

        public void SetFloat(string AnimationName,  float Value)
        {
            animator.SetFloat(AnimationName, Value);
        }
        public void SetBool(string AnimationName, bool runAnimation)
        {
            animator.SetBool(AnimationName, runAnimation);
        }
        public void SetTrigger(string AnimationName)
        {
            animator.SetTrigger(AnimationName);
        }
        public void ResetTrigger(string AnimationName)
        {
            animator.ResetTrigger(AnimationName);
        }
        public void StartAnimation()
        {
            onAnimationStart?.Invoke();
        }
        public void EndAnimation()
        {
            onAnimationEnd?.Invoke();
        }
    }
}

