using AnotherWorldProject.CombatSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class ShootAction : BaseAction
    {
        [SerializeField] int shootingRange = 2;
        [SerializeField] int damage = 1;
        [SerializeField] string Shoot = "Shoot";
        [SerializeField] string StopShooting = "StopShooting";
        //[SerializeField] Unit targetUnit;
        [SerializeField] Transform bulletProjectile;
        [SerializeField] Transform shootPointTransform;

        public override void ExecuteActionOnGridPosition(GridPosition gridPosition)
        {
            if (IsActionOnCooldown()) return;
            base.StartAction();
            Attack(gridPosition);
        }
        public override void ExecuteActionOnUnit(Unit unit)
        {
            if (IsActionOnCooldown()) return;
            
            base.StartAction();
            unitTarget = unit;
            AttackUnit();
        }
        protected override void StartAnimation()
        {

            animator.SetTrigger(Shoot);
            animator.ResetTrigger(StopShooting);
        }
        protected override void EndAnimation()
        {
            animator.ResetTrigger(Shoot);
            animator.SetTrigger(StopShooting);
        }
        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();

            targetGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            for (int x = -shootingRange; x <= shootingRange; x++)
            {
                for (int z = -shootingRange; z <= shootingRange; z++)
                {
                    GridPosition potentialPosition = new(x, z);
                    GridPosition testingPosition = targetGridPosition + potentialPosition;
                    if (!LevelGridSystem.Instance.IsValidGridPosition(testingPosition)) continue;
                    if (targetGridPosition == testingPosition) continue;
                    if (!LevelGridSystem.Instance.GetGridObject(testingPosition).Hasunits()) continue;
                    if (LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].GetFactionHandler().GetFactionName() == this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName()) continue;
                    if (LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].GetHealthHandler().IsDead()) continue;
                    if (Vector3.Distance(LevelGridSystem.Instance.GetGridObject(testingPosition).GetUnitList()[0].transform.position, this.transform.position) > shootingRange * Mathf.Pow(LevelGridSystem.Instance.GetGridCellSize(), 2)) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }

            return validGridPositionList;
        }

        //action logic
        public void Attack(GridPosition gridPosition)
        {
            unitTarget = LevelGridSystem.Instance.GetGridObject(gridPosition).GetUnitList()[0];
            
            AttackUnit();
        }
        public void AttackUnit()
        {
            currentActionCooldown = 0f;
            transform.LookAt(this.unitTarget.transform);
            Debug.Log($"Animation Start: {currentActionCooldown <= maxActionCooldown}");
        }

        //animation triggers
        protected override void AnimationStart()
        {
            
            Transform bulletTransform = Instantiate(bulletProjectile, shootPointTransform.position, Quaternion.identity);
            RangedProjectile rangedProjectile = bulletTransform.GetComponent<RangedProjectile>();
            
            rangedProjectile.FireProjectile(unitTarget.transform.position, damage, this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName());

        }
        protected override void AnimationEnd()
        {
            EndAction();
        }

        //public override void Cancel()
        //{
        //    base.Cancel();
        //    targetUnit = null;
        //}
        public float GetWeaponRange()
        {
            return shootingRange * LevelGridSystem.Instance.GetGridCellSize();
        }
    }
}

