using AnotherWorldProject.CombatSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class RangedAction : BaseAction
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
            if (IsOnCooldown()) return;
            base.StartAction();
            Attack(gridPosition);
        }
        public override void ExecuteActionOnUnit(Unit unit)
        {
            if (IsOnCooldown()) return;
            
            base.StartAction();
            unitTarget = unit;
            AttackUnit();
        }
        protected override void StartAnimation()
        {
           
            animator.SetTrigger(Shoot);
            animator.ResetTrigger(StopShooting);
            base.StartAnimation();
        }
        protected override void ResetAnimationTrigger()
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
                    if (!LevelGridSystem.Instance.GridPositionIsValid(testingPosition)) continue;
                    if (targetGridPosition == testingPosition) continue;
                    if (!LevelGridSystem.Instance.GetGridObject(testingPosition).HasObjectOnGrid()) continue;
                    Unit targetUnit = LevelGridSystem.Instance.GetGridObject(testingPosition).GetObjectList()[0] as Unit;
                    if (targetUnit == null) continue;
                    if(targetUnit.GetFactionHandler().GetFactionName() == this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName()) continue;
                    if (targetUnit.GetHealthHandler().IsDead()) continue;
                    if (Vector3.Distance(targetUnit.transform.position, this.transform.position) > shootingRange * Mathf.Pow(LevelGridSystem.Instance.GetGridCellSize(), 2)) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }

            return validGridPositionList;
        }

        //action logic
        public void Attack(GridPosition gridPosition)
        {
            unitTarget = LevelGridSystem.Instance.GetGridObject(gridPosition).GetObjectList()[0] as Unit;
            
            AttackUnit();
        }
        public void AttackUnit()
        {
            currentActionCooldown = 0f;
            transform.LookAt(this.unitTarget.transform);
            Debug.Log($"Animation Start: {currentActionCooldown <= maxActionCooldown}");
        }

        //animation triggers
        protected override void AnimationTriggered()
        {
            
            Transform bulletTransform = Instantiate(bulletProjectile, shootPointTransform.position, Quaternion.identity);
            RangedProjectile rangedProjectile = bulletTransform.GetComponent<RangedProjectile>();
            
            rangedProjectile.FireProjectile(unitTarget.transform.position, damage, this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName());

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

