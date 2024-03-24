using AnotherWorldProject.HealthSystem;
using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.CombatSystem
{
    public class RangedProjectile : MonoBehaviour
    {
        [SerializeField] DamageDefinition damageDefintion;
        [SerializeField] Transform impactTransform;
        [SerializeField] int damageOnImpact;
        [SerializeField] string factionOwner;
        Vector3 moveDirection;
        Vector3 targetPosition;
        [SerializeField]float moveSpeed = 1f;
        [SerializeField] float timer = 2f;
        private void Update()
        {
            if (timer > 0)
            {
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
                timer -= Time.deltaTime;
                return;
            }
                Destroy(this.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.TryGetComponent(out Unit unitHit))
            {
                if (unitHit.GetFactionHandler().GetFactionName() == factionOwner) return;
                List<HealthHandler> unitsToDamage = new() { unitHit.GetHealthHandler() };
                HandleDamageOnImpact(unitsToDamage, damageOnImpact);
                Destroy(this.gameObject);
                if (impactTransform != null)
                {
                    Instantiate(impactTransform, this.transform.position, Quaternion.identity);
                }
                Debug.Log("Collided with " + other.transform.name);
            }
        }

        void HandleDamageOnImpact(List<HealthHandler> unitsToDamage, int damage)
        {
            foreach(HealthHandler healthToDamage in unitsToDamage)
            {
                healthToDamage.RemoveFromCurrentHealth(damage);
            }
            
        }
        public void FireProjectile(Vector3 position, int damage, string factionOwner)
        {
            position.y = this.transform.position.y;
            moveDirection = (position - transform.position).normalized;
            damageOnImpact = damage;
            this.factionOwner = factionOwner;
        }
    }
}

