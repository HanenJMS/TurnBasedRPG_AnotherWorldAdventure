using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using UnityEngine;


namespace AnotherWorldProject.AISystem
{
    public class PatrolState : AIStateMachine
    {
        ActionHandler actionHandler;
        GridPosition patrolPosition;
        protected override void Awake()
        {
            base.Awake();
            actionHandler = GetComponentInParent<ActionHandler>();

        }
        private void Start()
        {
            aiHandler.SetCurrentState(this);
        }
        public override void RunStateBehavior()
        {
            if (actionHandler.GetAction<MoveAction>().IsMoving()) return;
            Debug.Log("Searching");
            foreach (Unit unit in aiHandler.GetDetectedUnitList())
            {
                
                if(unit.GetFactionHandler().GetFactionName() != GetComponentInParent<Unit>().GetFactionHandler().GetFactionName())
                {
                    aiHandler.SetGuardState();
                    Debug.Log("GoGuard");
                    return;
                }
            }
            int indexCount = actionHandler.GetAction<MoveAction>().GetValidActionGridPositionList().Count;
            if (indexCount <= 0) return;
            patrolPosition = actionHandler.GetAction<MoveAction>().GetValidActionGridPositionList()[UnityEngine.Random.Range(minInclusive: 0, indexCount)];
            if (actionHandler.GetAction<MoveAction>().IsValidActionOnGridPosition(patrolPosition))
            {
                actionHandler.GetAction<MoveAction>().ExecuteActionOnGridPosition(patrolPosition);
                Debug.Log("Patrolling");
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.transform.position, 5f);
        }
    }
}

