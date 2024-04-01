using AnotherWorldProject.ControllerSystem;
using AnotherWorldProject.GridSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingModeSystem : MonoBehaviour
    {
        public static BuildingModeSystem Instance { get; private set; }
        [SerializeField] int width, height;
        float cellSize;
        bool isBuildingMode = false;
        [SerializeField] List<GameObject> buildings = new();
        [SerializeField] Transform buildingContainerWorld;
        [SerializeField] GameObject selectedBuildingConstruction;

        public Action<bool> onSelectedDesiredConstruction;
        public Action<Action, Vector3> onConfirmPlacement;
        public Action onCancelBuildingMode;
        public Action onCancelDialog;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
        }
        private void Start()
        {
            cellSize = LevelGridSystem.Instance.GetGridCellSize();

        }
        private void Update()
        {

            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (HandleBuildingMode()) return;
            }
            if (Input.GetMouseButtonUp(1) && !EventSystem.current.IsPointerOverGameObject())
            {
                CancelBuildingMode();
            }
        }
        public List<GameObject> GetConstructableList()
        {
            return buildings;
        }


        /// <summary>
        /// places building on gridPosition and block the grid.
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <param name="blockGrid"></param>
        public void PlaceBuildingOnGrid(GridPosition gridPosition, bool blockGrid)
        {
            if (!LevelGridSystem.Instance.GridPositionIsValid(gridPosition)) return;
            if (LevelGridSystem.Instance.GetGridObject(gridPosition).HasObjectOnGrid()) return;
            Vector3 buildingPosition = LevelGridSystem.Instance.GetWorldPosition(gridPosition);
            GameObject newBuilding = Instantiate(selectedBuildingConstruction, buildingPosition, Quaternion.identity, buildingContainerWorld);
            GridObject gridObject = LevelGridSystem.Instance.GetGridObject(gridPosition);
            gridObject.AddObjectToGrid(newBuilding);
            gridObject.SetIsBlocked(blockGrid);
            newBuilding.transform.localScale = new(cellSize, 1, cellSize);
        }
        public bool HandleBuildingMode()
        {
            if (selectedBuildingConstruction == null) return false;
            GridPosition buildingGridPosition = LevelGridSystem.Instance.GetGridPosition(MouseWorld.GetMousePosition());
            if (!LevelGridSystem.Instance.GridPositionIsValid(buildingGridPosition)) return false;
            if (LevelGridSystem.Instance.GetGridObject(buildingGridPosition).HasObjectOnGrid())
            {
                CancelBuildingMode();
                return false;
            }
            onConfirmPlacement?.Invoke(() => PlaceBuildingOnGrid(buildingGridPosition, true), Input.mousePosition);

            return true;

        }

        private void CancelBuildingMode()
        {
            selectedBuildingConstruction = null;
            onCancelBuildingMode?.Invoke();
        }

        public void SetSelectedBuilding(GameObject building)
        {
            selectedBuildingConstruction = building;
        }


        public void ActivateBuildingMode()
        {
        }
    }
}

