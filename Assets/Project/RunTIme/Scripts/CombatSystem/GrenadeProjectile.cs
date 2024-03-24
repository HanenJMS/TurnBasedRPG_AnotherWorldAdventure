using AnotherWorldProject.GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace AnotherWorldProject.CombatSystem
{
    public class GrenadeProjectile : MonoBehaviour
    {
        Vector3 targetPosition;
        int damage;
        string factionOwner;
        float moveSpeed = 15f;
        public void LaunchGrenade(Vector3 targetPosition, int damage, string factionOwner)
        {
            this.targetPosition = targetPosition;
            this.damage = damage;
            this.factionOwner = factionOwner;
        }

        private void Update()
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            float withinDistance = .2f;
            if (Vector3.Distance(transform.position, targetPosition) < withinDistance)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

