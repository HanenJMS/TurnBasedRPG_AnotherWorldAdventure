using AnotherWorldProject.ControllerSystem;
using AnotherWorldProject.GridSystem;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {
        Vector3 targetPosition;
        GridPosition gridPosition;
        [SerializeField] Animator unitAnimator;
        NavMeshAgent agent;
        float minDistance = 1f;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            targetPosition = this.transform.position;
            gridPosition = LevelGrid.Instance.GetGridPosition(targetPosition);
        }
        private void Update()
        {
            Animation_RunningAim();
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(this.transform.position);
            if(newGridPosition != gridPosition)
            {
                LevelGrid.Instance.ChangingUnitGridPosition(gridPosition, newGridPosition, this);
                gridPosition = newGridPosition;
            }
        }

        private void Animation_RunningAim()
        {
            unitAnimator.SetBool("isRunning", Vector3.Distance(targetPosition, this.transform.position) > agent.stoppingDistance);
            agent.speed = 2.957f;
        }

        public void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            this.transform.LookAt(targetPosition);
            agent.SetDestination(targetPosition);
        }
    }
}

