using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public abstract class BaseAction : MonoBehaviour
    {
        [SerializeField] protected string ActionName = "BaseAction";

        protected bool isActive = false;
        protected bool isTriggered = false;

        [SerializeField]protected float maxActionCooldown = 0f;
        [SerializeField]protected float currentActionCooldown = float.MaxValue;
        [SerializeField] int actionCost = 1;

        ActionHandler actionHandler;
        protected UnitAnimator animator;
        protected Unit unitTarget;
        protected GridPosition targetGridPosition;
        
        protected virtual void Awake()
        {
            actionHandler = GetComponent<ActionHandler>();
            animator = GetComponentInChildren<UnitAnimator>();
            animator.SetBool(this.ActionName, false);
            isTriggered = false;
        }
        private void Update()
        {
            currentActionCooldown += Time.deltaTime;
        }
        private void OnEnable()
        {
            animator.onAnimationStart += AnimationStart;
            animator.onAnimationEnd += AnimationEnd;
        }

        protected virtual void StartAction()
        {
            isActive = true;
            currentActionCooldown = 0f;
            actionHandler.StartAction(this);
            actionHandler.UseActionPoints(this);
            StartAnimation();
        }
        protected virtual void EndAction()
        {
            actionHandler.Cancel();
        }
        public virtual bool IsRunning()
        {
            return isActive;
        }
        public virtual void Cancel()
        {
            isActive = false;

            EndAnimation();
        }
        
        //action executers
        public abstract void ExecuteActionOnUnit(Unit target);
        public abstract void ExecuteActionOnGridPosition(GridPosition gridPosition);

        //validation
        public bool IsValidActionOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }
        public abstract List<GridPosition> GetValidActionGridPositionList();
        public bool IsActionOnCooldown()
        {
            return currentActionCooldown < maxActionCooldown;
        }


        //Animation
        protected virtual void StartAnimation()
        {
        }
        protected abstract void EndAnimation();
        
        //animation action events
        protected virtual void AnimationStart()
        {
        }
        protected virtual void AnimationEnd()
        {
        }

        //action information
        public override string ToString()
        {
            return this.ActionName;
        }
        public virtual int GetActionCost()
        {
            return actionCost;
        }
    }
}

