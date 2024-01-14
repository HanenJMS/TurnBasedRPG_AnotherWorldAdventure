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
        ActionHandler actionHandler;
        protected UnitAnimator animator;
        protected GridPosition gridPosition;
        [SerializeField] int actionCost = 1;
        protected virtual void Awake()
        {
            actionHandler = GetComponent<ActionHandler>();
            animator = GetComponentInChildren<UnitAnimator>();
        }
        private void Start()
        {
            animator.onAnimationStart += StartAnimation;
            animator.onEndAnimation += EndAnimation;
        }
        protected virtual void Update()
        {
            if (!isActive)
            {
                Cancel();
                return;
            }
        }
        
        //Action
        protected void StartAction()
        {

            isActive = true;
            actionHandler.SetCurrentAction(this);
            actionHandler.UseActionPoints(this);
            animator.SetBool(this.ActionName, isActive);
        }
        protected void EndAction()
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
            animator.SetBool(this.ActionName, false);
        }
        public virtual int GetActionCost()
        {
            return actionCost;
        }

        //Grid 
        public abstract void ExecuteActionOnGridPosition(GridPosition gridPosition);
        public bool IsValidActionOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }
        public abstract List<GridPosition> GetValidActionGridPositionList();

        //Animation
        public virtual void StartAnimation()
        {

        }
        public virtual void EndAnimation()
        {

        }
        //
        public override string ToString()
        {
            return this.ActionName;
        }
    }
}

