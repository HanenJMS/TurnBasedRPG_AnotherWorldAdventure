using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.FactionSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System;
using UnityEngine;


namespace AnotherWorldProject.AISystem
{
    public class PatrolState : AIStateMachine
    {
        MoveAction moveAction;
        ActionHandler actionHandler;
        GridPosition patrolPosition;
        protected override void Awake()
        {
            base.Awake();
            moveAction = GetComponentInParent<MoveAction>();
            actionHandler = GetComponentInParent<ActionHandler>();

        }
        private void Start()
        {
            aiHandler.SetCurrentState(this);
        }
        public override void RunStateBehavior()
        {
            if (moveAction.IsMoving()) return;
            int indexCount = moveAction.GetValidActionGridPositionList().Count;
            if (indexCount <= 0) return;
            patrolPosition = moveAction.GetValidActionGridPositionList()[UnityEngine.Random.Range(minInclusive: 0, indexCount)];
            if(moveAction.IsValidActionOnGridPosition(patrolPosition))
            {
                moveAction.ExecuteActionOnGridPosition(patrolPosition);
            }
        }
    }
}

