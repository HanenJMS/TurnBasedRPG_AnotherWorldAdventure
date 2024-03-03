using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingButtonUI : MonoBehaviour
    {
        Button button;
        GameObject building;
        [SerializeField]
        TextMeshProUGUI text;
        private void Awake()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                BuildingSystem.Instance.SetSelectedBuilding(building);
                BuildingSystem.Instance.ActivateSystem();
            });
        }
        public void SetBuilding(GameObject building)
        {
            this.building = building;
            text.text = building.gameObject.name;
        }

    }

}
