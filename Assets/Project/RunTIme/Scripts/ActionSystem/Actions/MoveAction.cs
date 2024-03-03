using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.ActionSystem
{
    public class MoveAction : BaseAction
    {
        Vector3 targetPosition;
       
        NavMeshAgent agent;
        float speed = 0f;
        [SerializeField] int maxDistance = 2;
        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            UpdateAnimator();
            if (!isActive) return;
            
            
        }
        private void Start()
        {
            targetGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            
        }
        protected override void StartAnimation()
        {
            //animator.SetBool(ActionName, isActive);
        }
        protected override void EndAnimation()
        {
            //animator.SetBool(ActionName, isActive);
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }
        public void MoveToWithinStoppingDistance(float stoppingDistance)
        {
            agent.stoppingDistance = stoppingDistance;
        }
        public bool GetIsInDistance()
        {
            return Vector3.Distance(targetPosition, this.transform.position) <= agent.stoppingDistance;
        }
        public int GetGridMaxDistance()
        {
            return maxDistance;
        }
        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();
            targetGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            for (int x = -maxDistance; x <= maxDistance; x++)
            {
                for (int z = -maxDistance; z <= maxDistance; z++)
                {
                    GridPosition potentialPosition = new(x, z);
                    GridPosition testingPosition = targetGridPosition + potentialPosition;
                    if (!LevelGridSystem.Instance.IsValidGridPosition(testingPosition)) continue;
                    if (targetGridPosition == testingPosition) continue;
                    //if (Pathfinding.Instance.GetNode(testingPosition).GetIsPathBlocked()) continue;
                    validGridPositionList.Add(testingPosition);
                }
            }
            return validGridPositionList;
        }
        public override void ExecuteActionOnGridPosition(GridPosition targetPosition)
        {
            base.StartAction();
            this.targetGridPosition = targetPosition;
            agent.SetDestination(LevelGridSystem.Instance.GetWorldPosition(targetPosition));
        }
        public override void Cancel()
        {
            base.Cancel();
        }

        public override void ExecuteActionOnUnit(Unit target)
        {
            base.StartAction();
        }
        public bool IsMoving()
        {
            return Vector3.Distance(targetPosition, this.transform.position) >= agent.stoppingDistance;
        }
    }
}

