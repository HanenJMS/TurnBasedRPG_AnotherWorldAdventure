using AnotherWorldProject.ActionSystem;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.MovementSystem
{
    public class MovementHandler : MonoBehaviour
    {
        Vector3 targetPosition;
        GameObject targetObject;
        ActionHandler actionHandler;
        NavMeshAgent agent;
        float minDistance;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            actionHandler = GetComponent<ActionHandler>();
            targetPosition = this.transform.position;
        }


        public void MoveToPosition(Vector3 targetPosition)
        {

        }
    }
}

