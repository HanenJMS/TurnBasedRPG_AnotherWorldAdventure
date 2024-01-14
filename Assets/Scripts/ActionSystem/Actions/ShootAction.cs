using AnotherWorldProject.GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AnotherWorldProject.ActionSystem
{
    public class ShootAction : BaseAction
    {

        Vector3 targetPosition;
        [SerializeField] Animator unitAnimator;
        [SerializeField] int maxDistance = 5;
        public override void ExecuteActionOnGridPosition(GridPosition gridPosition)
        {
            
        }

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();
            gridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            for (int x = -maxDistance; x <= maxDistance; x++)
            {
                for (int z = -maxDistance; z <= maxDistance; z++)
                {
                    GridPosition potentialPosition = new(x, z);
                    GridPosition testingPosition = gridPosition + potentialPosition;
                    if (!LevelGridSystem.Instance.IsValidGridPosition(testingPosition)) continue;
                    if (gridPosition == testingPosition) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }
            return validGridPositionList;
        }
    }
}

