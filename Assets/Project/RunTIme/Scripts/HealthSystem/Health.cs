using UnityEngine;
namespace AnotherWorldProject.HealthSystem
{
    [System.Serializable]
    public class Health
    {
        [SerializeField] int maxHealth = 100;
        [SerializeField] int currentHealth = 0;
        public void AddHealth(int health)
        {
            Mathf.Clamp(currentHealth += health, 0, maxHealth);
        }
        public void RemoveHealth(int health)
        {
            Mathf.Clamp(currentHealth -= health, 0, maxHealth);
        }

        public float GetCurrentHealthPercentage()
        {
            return Mathf.Clamp01((float)currentHealth / maxHealth);
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
