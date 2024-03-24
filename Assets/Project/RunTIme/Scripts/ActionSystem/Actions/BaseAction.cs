using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public abstract class BaseAction : MonoBehaviour, IEquatable<BaseAction>
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
        }
        private void LateUpdate()
        {
            currentActionCooldown += Time.deltaTime;
            if (currentActionCooldown > maxActionCooldown)
            {
                ResetAnimationTrigger();
            }
            
        }
        public abstract void ExecuteActionOnGridPosition(GridPosition gridPosition);
        public bool CanBePerformedOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }
        public abstract List<GridPosition> GetValidActionGridPositionList();
        private void OnEnable()
        {
            animator.onAnimationStart += AnimationTriggered;
        }

        protected virtual void StartAction()
        {
            isActive = true;
            currentActionCooldown = 0f;
            actionHandler.StartAction(this);
            
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

            ResetAnimationTrigger();
        }
        
        //action executers
        public abstract void ExecuteActionOnUnit(Unit target);

        public bool IsOnCooldown()
        {
            return currentActionCooldown < maxActionCooldown;
        }


        //Animation
        protected virtual void StartAnimation()
        {
            actionHandler.UseActionPoints(this);
        }
        protected abstract void ResetAnimationTrigger();
        
        //animation action events
        protected virtual void AnimationTriggered()
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

        public bool Equals(BaseAction other)
        {
            throw new NotImplementedException();
        }
    }
}

