using AnotherWorldProject.GridSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.ActionSystem
{
    public class MoveAction : BaseAction
    {
        Vector3 targetPosition;
        GridPosition gridPosition;
        NavMeshAgent agent;
        [SerializeField] Animator unitAnimator;
        [SerializeField] int minDistance= 2, maxDistance = 2;
        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
            unitAnimator = GetComponentInChildren<Animator>();
            unitAnimator.SetBool("isRunning", false);
            targetPosition = this.transform.position;
            
        }
        private void Start()
        {
            gridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
        }
        protected override void Update()
        {
            base.Update();
            Animation_RunningAim();
        }
        private void Animation_RunningAim()
        {
            unitAnimator.SetBool("isRunning", Vector3.Distance(targetPosition, this.transform.position) > agent.stoppingDistance);
            agent.speed = 2.957f;
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
                    if(gridPosition == testingPosition) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }
            return validGridPositionList;
        }
        public override void ExecuteActionOnGridPosition(GridPosition targetPosition)
        {
            this.targetPosition = LevelGridSystem.Instance.GetWorldPosition(targetPosition);
            this.transform.LookAt(this.targetPosition);
            agent.SetDestination(this.targetPosition);
            base.StartAction();
            isActive = true;
        }
        public override void Cancel()
        {
            base.Cancel();
            unitAnimator.SetBool("isRunning", isActive);
        }
    }
}

