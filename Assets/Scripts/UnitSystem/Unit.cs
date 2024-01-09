using AnotherWorldProject.ControllerSystem;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {
        Vector3 targetPosition;
        NavMeshAgent agent;
        float minDistance = 1f;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {

            if(Input.GetMouseButtonDown(0))
            {
                Move(MouseWorld.GetMousePosition());
            }
        }
        private void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            agent.SetDestination(targetPosition);
        }
    }
}

