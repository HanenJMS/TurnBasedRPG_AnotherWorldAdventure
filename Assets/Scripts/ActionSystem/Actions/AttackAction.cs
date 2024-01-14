using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class AttackAction : BaseAction
    {
        [SerializeField] int minDistance = 2, maxDistance = 2;
        [SerializeField] int damage = 1;
        [SerializeField] Unit targetUnit;
        [SerializeField] bool isTriggered = false;
        [SerializeField] Transform bulletProjectile;
        [SerializeField] Transform shootPointTransform;
        protected override void Update()
        {
            base.Update();
            if (isTriggered) return;
        }
        public override void ExecuteActionOnGridPosition(GridPosition gridPosition)
        {
            if(isTriggered) return;
            base.StartAction();
            Attack(gridPosition);
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
                    if (LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].GetFactionHandler().IsEnemyFaction() == this.gameObject.GetComponent<Unit>().GetFactionHandler().IsEnemyFaction()) continue;
                    if (LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].GetHealthHandler().IsDead()) continue;
                    if (Vector3.Distance(LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].transform.position, this.transform.position) > maxDistance * Mathf.Pow(LevelGridSystem.Instance.GetGridCellSize(), 2)) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }

            return validGridPositionList;
        }
        public void Attack(GridPosition gridPosition)
        {
            targetUnit = LevelGridSystem.Instance.GetGridObject(gridPosition).GetUnitList()[0];
            isTriggered = true;
            AttackUnit(targetUnit);
        }
        public override void StartAnimation()
        {
            Transform bulletTransform = Instantiate(bulletProjectile, shootPointTransform.position, Quaternion.identity);
            RangedProjectile rangedProjectile = bulletTransform.GetComponent < RangedProjectile>(); 
            targetUnit.GetHealthHandler().RemoveFromCurrentHealth(damage);
            Debug.Log($"hit {targetUnit.ToString()}");
            
        }
        public override void EndAnimation()
        {
            EndAction();
            isTriggered = false;
        }
        public void AttackUnit(Unit targetUnit)
        {
            transform.LookAt(this.targetUnit.transform);
        }
        public override void Cancel()
        {
            base.Cancel();
            targetUnit = null;
            isTriggered = false;
        }
    }
}

