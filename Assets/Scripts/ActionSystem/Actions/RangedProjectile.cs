using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class RangedProjectile : MonoBehaviour
    {
        Vector3 targetPosition;
        Vector3 moveDirection;
        float moveSpeed = 200f;
        private void Update()
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }
        public void SetTarget(Vector3 position)
        {
            targetPosition = position;
            moveDirection = (targetPosition - transform.position).normalized;
        }
    }
}

