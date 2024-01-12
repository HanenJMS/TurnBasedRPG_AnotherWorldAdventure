using AnotherWorldProject.GridSystem;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected bool isActive = false;
        
        protected virtual void Update()
        {
            if (!isActive)
            {
                Cancel();
                return;
            }
        }

        public bool IsValidActionOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }

        public virtual List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();
            return validGridPositionList;
        }
        protected virtual void Cancel()
        {
            isActive = false;
        }
    }
}

