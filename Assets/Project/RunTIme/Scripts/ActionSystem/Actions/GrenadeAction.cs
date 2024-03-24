using AnotherWorldProject.CombatSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class GrenadeAction : BaseAction
    {
        [SerializeField] int shootingRange = 2;
        [SerializeField] int damage = 1;
        //[SerializeField] Unit targetUnit;
        [SerializeField] Transform grenadeProjectile;
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
            //base.StartAnimation();
        }
        protected override void ResetAnimationTrigger()
        {
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
                    if ((LevelGridSystem.Instance.GetGridObject(testingPosition).GetObjectList()[0] as Unit).GetFactionHandler().GetFactionName() == this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName()) continue;
                    if ((LevelGridSystem.Instance.GetGridObject(testingPosition).GetObjectList()[0] as Unit).GetHealthHandler().IsDead()) continue;
                    if (Vector3.Distance((LevelGridSystem.Instance.GetGridObject(testingPosition).GetObjectList()[0] as Unit).transform.position, this.transform.position) > shootingRange * Mathf.Pow(LevelGridSystem.Instance.GetGridCellSize(), 2)) continue;
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
            Transform bulletTransform = Instantiate(grenadeProjectile, shootPointTransform.position, Quaternion.identity);
            GrenadeProjectile rangedProjectile = bulletTransform.GetComponent<GrenadeProjectile>();
            rangedProjectile.LaunchGrenade(unitTarget.transform.position, damage, this.gameObject.GetComponent<Unit>().GetFactionHandler().GetFactionName());
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

