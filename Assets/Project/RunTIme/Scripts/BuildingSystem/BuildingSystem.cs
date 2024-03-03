using AnotherWorldProject.ControllerSystem;
using AnotherWorldProject.GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingSystem : MonoBehaviour
    {
        public static BuildingSystem Instance { get; private set; }
        [SerializeField] int width, height;
        float cellSize;
        bool isActive = false;

        [SerializeField] List<GameObject> buildings = new();
        [SerializeField] Transform buildingContainerWorld;
        [SerializeField] GameObject selectedBuilding;
        GridSystem<BuildingNode> gridSystem;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
            gridSystem = new GridSystem<BuildingNode>(width, height, cellSize, (GridSystem<BuildingNode> g, GridPosition gp) => new BuildingNode(gp));
        }
        private void Start()
        {
            cellSize = LevelGridSystem.Instance.GetGridCellSize();
            
        }
        private void Update()
        {
            if (!isActive) return;
            if (selectedBuilding == null) return;
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                GridPosition buildingGridPosition = LevelGridSystem.Instance.GetGridPosition(MouseWorld.GetMousePosition());
                Vector3 buildingPosition = LevelGridSystem.Instance.GetWorldPosition(buildingGridPosition);
                if (LevelGridSystem.Instance.GetGridObject(buildingGridPosition).Hasunits())
                {
                    selectedBuilding = null;
                    return;
                }
                GameObject newBuilding = GameObject.Instantiate(selectedBuilding, buildingPosition, Quaternion.identity,buildingContainerWorld);
                newBuilding.transform.localScale = new(cellSize, 1, cellSize);
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                selectedBuilding = null;
                isActive = false;
                return;
            }
        }

        public void SetSelectedBuilding(GameObject building)
        {
            selectedBuilding = building;
        }

        public List<GameObject> GetBuildingTypes()
        {
            return buildings;
        }
        public void ActivateSystem()
        {
            isActive = true;
        }
    }
}

