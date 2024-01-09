using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {
        Vector3 targetPosition;
        float minDistance = 1f;
        private void Update()
        {
            if (Vector3.Distance(transform.position, targetPosition) > minDistance)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                float moveSpeed = 4f;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
        private void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    }
}

