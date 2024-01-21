using System;
using UnityEngine;
namespace AnotherWorldProject.HealthSystem
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] Health health;
        [SerializeField] bool isDead = false;
        public Action onDead;
        public Action onHealthChange;
        private void Start()
        {
            health.SetHealth(health.GetMaxHealth());
            onHealthChange?.Invoke();
        }
        public void AddToCurrentHealth(int heal)
        {

            health.AddHealth(heal);
            onHealthChange?.Invoke();
        }
        public void RemoveFromCurrentHealth(int damage)
        {
            health.RemoveHealth(damage);
            onHealthChange?.Invoke();
            if (GetCurrentHealth() <= 0)
            {
                isDead = true;
                onDead?.Invoke();
            }
        }
        public bool IsDead()
        {
            return isDead;
        }
        public int GetCurrentHealth()
        {
            return health.GetCurrentHealth();
        }
        public float GetCurrentHealthPercentage()
        {
            return health.GetCurrentHealthPercentage();
        }
        public override string ToString()
        {
            return health.ToString();
        }
    }

}
