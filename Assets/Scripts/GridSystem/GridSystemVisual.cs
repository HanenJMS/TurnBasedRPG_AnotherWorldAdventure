using AnotherWorldProject.ControllerSystem;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
namespace AnotherWorldProject.GridSystem
{
    public class GridSystemVisual : MonoBehaviour
    {
        public static GridSystemVisual Instance { get; private set; }
        
        [SerializeField] Transform gridPositionVisual;
        Dictionary<GridPosition, MeshRenderer> gridPositionVisualList;
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
            gridPositionVisualList = new();
        }
        private void Start()
        {
            foreach (GridPosition gridPosition in LevelGridSystem.Instance.GetAllGridPositions())
            {
                Transform gridVisualTransform = Instantiate(gridPositionVisual, LevelGridSystem.Instance.GetWorldPosition(gridPosition), Quaternion.identity, this.transform);
                gridPositionVisualList.Add(gridPosition, gridVisualTransform.GetComponentInChildren<MeshRenderer>());
            }
            UnitActionSystem.instance.onSelectedUnit += ShowSelectedUnitMoveActionVisual;
            LevelGridSystem.Instance.onUpdateGridPosition += ShowSelectedUnitMoveActionVisual;
            HideAllGridPosition();
        }
        void HideAllGridPosition()
        {
            foreach(KeyValuePair<GridPosition, MeshRenderer> grid in gridPositionVisualList)
            {
                grid.Value.enabled = false;
            }
        }
        void ShowSelectedUnitMoveActionVisual()
        {
            ShowGridPositions(UnitActionSystem.instance.GetSelectedUnit().GetMoveAction().GetValidActionGridPositionList());
        }
        void ShowGridPositions(List<GridPosition> positions)
        {
            HideAllGridPosition();
            foreach (GridPosition gridPosition in positions)
            {
                if(gridPositionVisualList.ContainsKey(gridPosition))
                {
                    gridPositionVisualList[gridPosition].enabled = true;
                }
            }
        }
    }
}

