using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class AttackAction : BaseAction
    {
        [SerializeField] int minDistance = 2, maxDistance = 2;

        GridPosition gridPosition;

        public override void ExecuteActionOnGridPosition(GridPosition gridPosition)
        {
            Attack(gridPosition);
            base.StartAction();
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
                    if (!LevelGridSystem.Instance.GetGridObject(testingPosition).Hasunits()) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }

            return validGridPositionList;
        }
        public void Attack(GridPosition gridPosition)
        {
            foreach(Unit attackUnit in LevelGridSystem.Instance.GetGridObject(gridPosition).GetUnitList())
            {
                Debug.Log("Attacking! "+attackUnit.name);
            }
            
        }
    }
}

