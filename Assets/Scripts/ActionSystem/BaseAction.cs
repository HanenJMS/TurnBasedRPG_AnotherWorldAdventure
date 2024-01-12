using AnotherWorldProject.GridSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public abstract class BaseAction : MonoBehaviour
    {
        [SerializeField] string ActionName = "BaseAction";
        protected bool isActive = false;
        ActionHandler actionHandler;
        int actionCost = 1;
        protected virtual void Awake()
        {
            actionHandler = GetComponent<ActionHandler>();
        }
        protected virtual void Update()
        {
            if (!isActive)
            {
                Cancel();
                return;
            }
        }
        
        //Action States
        protected void StartAction()
        {
            actionHandler.SetCurrentAction(this);
            actionHandler.UseActionPoints(this);
        }
        public virtual bool IsRunning()
        {
            return isActive;
        }
        public virtual void Cancel()
        {
            isActive = false;
        }

        //Grid States
        public abstract void ExecuteActionOnGridPosition(GridPosition gridPosition);
        public bool IsValidActionOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }
        public abstract List<GridPosition> GetValidActionGridPositionList();

        
        public virtual int GetActionCost()
        {
            return actionCost;
        }

        //
        public override string ToString()
        {
            return ActionName;
        }
    }
}

