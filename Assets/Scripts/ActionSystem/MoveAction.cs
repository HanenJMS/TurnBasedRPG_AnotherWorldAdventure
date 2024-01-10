using AnotherWorldProject.GridSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.ActionSystem
{
    public class MoveAction : MonoBehaviour
    {
        Vector3 targetPosition;
        GridPosition gridPosition;
        NavMeshAgent agent;
        [SerializeField] Animator unitAnimator;
        [SerializeField] int minDistance= 2, maxDistance = 2;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            unitAnimator = GetComponentInChildren<Animator>();
            unitAnimator.SetBool("isRunning", false);
            targetPosition = this.transform.position;
            
        }
        private void Start()
        {
            gridPosition = LevelGridSystem.Instance.GetGridPosition(targetPosition);
        }
        private void Update()
        {
            Animation_RunningAim();
        }
        private void Animation_RunningAim()
        {
            unitAnimator.SetBool("isRunning", Vector3.Distance(targetPosition, this.transform.position) > agent.stoppingDistance);
            agent.speed = 2.957f;
        }
        public bool IsValidActionOnGridPosition(GridPosition gridPosition)
        {
            return GetValidActionGridPositionList().Contains(gridPosition);
        }

        public List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();
            for(int x = -maxDistance; x <= maxDistance; x++)
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
        public void Move(GridPosition targetPosition)
        {
            this.targetPosition = LevelGridSystem.Instance.GetWorldPosition(targetPosition);
            this.transform.LookAt(this.targetPosition);
            agent.SetDestination(this.targetPosition);
        }
    }
}

