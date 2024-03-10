using AnotherWorldProject.ControllerSystem;
using AnotherWorldProject.GridSystem;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingInteractionSystem : MonoBehaviour
    {
        public static BuildingInteractionSystem Instance { get; private set; }
        [SerializeField] LayerMask buildingLayerMask;
        [SerializeField] Building selectedBuilding;
        
        public Action onSelectedBuilding;
        public Action onMouseClickBuilding;
        public Action onEndInteraction;
        bool isActive = false;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
        }
        private void Start()
        {
            ActivateBuildingInteraction();
        }
        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                onEndInteraction?.Invoke();
                Vector3 mousePosition = MouseWorld.GetMousePosition();
                GridPosition gridPlacementPosition = LevelGridSystem.Instance.GetGridPosition(mousePosition);
                if (!LevelGridSystem.Instance.IsValidGridPosition(gridPlacementPosition)) return;
                
                GridObject gridPositionObject = LevelGridSystem.Instance.GetGridObject(gridPlacementPosition);

                if (!gridPositionObject.HasObjectOnGrid()) return;
                if (gridPositionObject.GetObjectList()[0] is not GameObject) return;
                (gridPositionObject.GetObjectList()[0] as GameObject).TryGetComponent(out Building building);
                if (building != null)
                {
                    selectedBuilding = building;
                    onSelectedBuilding?.Invoke();
                    return;
                }
            }

        }
        public void ActivateBuildingInteraction()
        {
            isActive = true;
            onMouseClickBuilding?.Invoke();
        }
        public void EndBuildingInteraction()
        {
            onEndInteraction?.Invoke();
        }
        public Building GetSelectedBuilding() => selectedBuilding;
    }
}


