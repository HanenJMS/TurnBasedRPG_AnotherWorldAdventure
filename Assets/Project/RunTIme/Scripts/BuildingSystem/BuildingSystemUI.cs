using UnityEngine;
namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingSystemUI : MonoBehaviour
    {
        [SerializeField] Transform buildingButtonContainer;
        [SerializeField] Transform buildingButtonUI;

        private void Start()
        {
            foreach(GameObject building in BuildingSystem.Instance.GetBuildingTypes())
            {
                GameObject buttonUI = Instantiate(buildingButtonUI, buildingButtonContainer).gameObject;
                buttonUI.GetComponent<BuildingButtonUI>().SetBuilding(building);
            }
            
        }
    }

}
