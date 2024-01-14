using UnityEngine;
namespace AnotherWorldProject.HealthSystem
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] Health health;

        private void Start()
        {
            health.SetHealth(health.GetMaxHealth());
        }

        public void RemoveFromCurrentHealth(int damage)
        {
            health.RemoveHealth(damage);
        }
        public void AddToCurrentHealth(int heal)
        {
            health.AddHealth(heal);
        }
        public bool IsDead()
        {
            return health.IsDead();
        }
        public int GetCurrentHealth()
        {
            return health.GetCurrentHealth();
        }
        public override string ToString()
        {
            return health.ToString();
        }
    }

}
