using UnityEngine;
namespace AnotherWorldProject.HealthSystem
{
    [System.Serializable]
    public class Health
    {
        [SerializeField] int maxHealth = 100;
        [SerializeField] int currentHealth = 0;
        [SerializeField] bool isDead = false;
        public void AddHealth(int health)
        {
            Mathf.Clamp(currentHealth += health, 0, maxHealth);
        }
        public void RemoveHealth(int health)
        {
            if (isDead) return;
            Mathf.Clamp(currentHealth -= health, 0, maxHealth);
            if(currentHealth <= 0)
            {
                isDead = true;
            }
        }
        public bool IsDead()
        {
            return isDead;
        }
        public int GetCurrentHealth()
        {
            return currentHealth;
        }
        public int GetMaxHealth() 
        {
            return maxHealth;
        }
        public void SetHealth(int Health)
        {
            currentHealth = Health;
        }
        public override string ToString()
        {
            return $"{currentHealth}/{maxHealth}";
        }
    }

}
