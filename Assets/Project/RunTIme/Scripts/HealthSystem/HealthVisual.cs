using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnotherWorldProject.HealthSystem
{
    public class HealthVisual : MonoBehaviour
    {
        HealthHandler handler;
        TextMeshProUGUI healthText;
        [SerializeField] Image healthBarImage;
        private void Awake()
        {
            healthText = GetComponentInChildren<TextMeshProUGUI>();   
        }
        private void Start()
        {
            handler = GetComponentInParent<HealthHandler>();
            handler.onHealthChange += UpdateHealthVisual;
            UpdateHealthVisual();
        }
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
        void UpdateHealthVisual()
        {
            healthText.text = handler.ToString();
            healthBarImage.fillAmount = handler.GetCurrentHealthPercentage();
            Debug.Log("health percentage = " + handler.GetCurrentHealthPercentage());
        }
    }

}
