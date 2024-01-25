using AnotherWorldProject.UnitSystem;
using UnityEngine;

namespace AnotherWorldProject.CombatSystem
{
    public class RangedProjectile : MonoBehaviour
    {
        [SerializeField] Transform impactTransform;
        [SerializeField] int damageOnImpact;
        [SerializeField] string factionOwner;
        Vector3 moveDirection;
        float moveSpeed = 50f;
        float timer = 2f;
        private void Update()
        {
            if (timer > 0)
            {
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
                timer -= Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.TryGetComponent(out Unit unitHit))
            {
                if (unitHit.GetFactionHandler().GetFactionName() == factionOwner) return;
                unitHit.GetHealthHandler().RemoveFromCurrentHealth(damageOnImpact);
            }
            if (impactTransform != null)
            {
                Instantiate(impactTransform, this.transform.position, Quaternion.identity);
            }
            Debug.Log("Collided with " + other.transform.name);
            Destroy(this.gameObject);
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

