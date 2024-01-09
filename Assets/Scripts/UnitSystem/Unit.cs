using AnotherWorldProject.ControllerSystem;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {
        Vector3 targetPosition;
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
        }
        private void Update()
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

