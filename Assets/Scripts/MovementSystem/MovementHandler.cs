using AnotherWorldProject.GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.MovementSystem
{
    public class MovementHandler : MonoBehaviour
    {
        //Vector3 targetPosition;
        //NavMeshAgent agent;
        //[SerializeField] int minDistance = 2, maxDistance = 2;
        //protected override void Awake()
        //{
        //    base.Awake();
        //    agent = GetComponent<NavMeshAgent>();
        //    animator.SetBool(this.ActionName, false);
        //    targetPosition = this.transform.position;

        //}
        //private void Start()
        //{
        //    targetGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);

        //}
        ////protected override void RunActionLogic()
        ////{
        ////    Animation_RunningAim();
        ////    isActive = Vector3.Distance(targetPosition, this.transform.position) > agent.stoppingDistance;
        ////}
        //private void Animation_RunningAim()
        //{
        //    animator.SetBool(this.ActionName, Vector3.Distance(targetPosition, this.transform.position) > agent.stoppingDistance);
        //    agent.speed = 2.957f;
        //}
        //public void MoveToWithinStoppingDistance(float stoppingDistance)
        //{
        //    agent.stoppingDistance = stoppingDistance;
        //}
        //public override List<GridPosition> GetValidActionGridPositionList()
        //{
        //    List<GridPosition> validGridPositionList = new();
        //    targetGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
        //    for (int x = -maxDistance; x <= maxDistance; x++)
        //    {
        //        for (int z = -maxDistance; z <= maxDistance; z++)
        //        {
        //            GridPosition potentialPosition = new(x, z);
        //            GridPosition testingPosition = targetGridPosition + potentialPosition;
        //            if (!LevelGridSystem.Instance.IsValidGridPosition(testingPosition)) continue;
        //            if (targetGridPosition == testingPosition) continue;
        //            validGridPositionList.Add(testingPosition);
        //        }
        //    }
        //    return validGridPositionList;
        //}
        //public override void ExecuteActionOnGridPosition(GridPosition targetPosition)
        //{
        //    this.targetPosition = LevelGridSystem.Instance.GetWorldPosition(targetPosition);
        //    this.transform.LookAt(this.targetPosition);
        //    agent.SetDestination(this.targetPosition);
        //    base.StartAction();
        //}
        //public override void Cancel()
        //{
        //    base.Cancel();
        //}

        //public override void ExecuteActionOnUnit(Unit target)
        //{

        //}
    }
}

