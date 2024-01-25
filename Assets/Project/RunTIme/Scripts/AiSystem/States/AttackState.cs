using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem
{
    public class AttackState : AIStateMachine
    {
        [SerializeField] Unit Target;
        ActionHandler actionHandler;
        protected override void Awake()
        {
            base.Awake();
            actionHandler = GetComponentInParent<ActionHandler>();
        }

        public override void RunStateBehavior()
        {
            if(!HasTargetEnemy())
            {
                SetTarget();
            }
            if (Target == null) return;
            if (Target.GetHealthHandler().IsDead())
            {
                Target = null;
                return;
            }
            GridPosition targetPosition = LevelGridSystem.Instance.GetGridPosition(Target.transform.position);
            if (!IsMovingToTarget())
            {
                if (!actionHandler.HasEnoughActionPoints(actionHandler.GetAction<ShootAction>())) return;
                actionHandler.GetAction<ShootAction>().ExecuteActionOnUnit(Target);
                Debug.Log("isShooting");
            }
        }
        public bool IsMovingToTarget()
        {

            actionHandler.GetAction<MoveAction>().MoveToWithinStoppingDistance(actionHandler.GetAction<ShootAction>().GetWeaponRange());
            actionHandler.GetAction<MoveAction>().ExecuteActionOnUnit(Target);
            return Vector3.Distance(Target.transform.position, this.transform.position) > actionHandler.GetAction<ShootAction>().GetWeaponRange();
        }
        private bool HasTargetEnemy()
        {
            return Target != null;
        }

        void SetTarget()
        {
            if (aiHandler.GetDetectedUnitList() == null) return;
            foreach(Unit unit in aiHandler.GetDetectedUnitList())
            {
                if (unit == null) continue;
                if(unit.GetHealthHandler().IsDead()) continue;
                
                if(unit.GetFactionHandler().GetFactionName() != aiHandler.GetAiUnit().GetFactionHandler().GetFactionName())
                {
                    if (Target != null && Vector3.Distance(this.transform.position, Target.transform.position) <= Vector3.Distance(this.transform.position, unit.transform.position)) continue;
                    Target = unit;
                }
            }
            if(Target == null)
            {
                aiHandler.CurrentStateFailed();
            }
        }
    }
}

