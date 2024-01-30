using AnotherWorldProject.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class LevelGridSystem : MonoBehaviour
    {
        public static LevelGridSystem Instance { get; private set; }
        public Action onUpdateGridPosition;
        [SerializeField] int width, height, cellsize;
        [SerializeField] Transform debugObject;
        GridSystem<GridObject> gridSystem;
        // Start is called before the first frame update
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;

            gridSystem = new GridSystem<GridObject>(width, height, cellsize, (GridSystem<GridObject> g, GridPosition gridPosition) => new(g, gridPosition));
            //gridSystem.CreateDebugObject(debugObject);
        }

        //Handling Unit
        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            gridSystem.GetGridObject(gridPosition).AddUnit(unit);
        }
        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GetGridObject(gridPosition).RemoveUnit(unit);
        }
        public void ChangingUnitGridPosition(GridPosition from, GridPosition to, Unit unit)
        {
            RemoveUnitAtGridPosition(from, unit);
            AddUnitAtGridPosition(to, unit);
            onUpdateGridPosition?.Invoke();
        }
        public List<Unit> GetUnitsAtGridPosition(GridPosition gridPosition)
        {
            return gridSystem.GetGridObject(gridPosition).GetUnitList();
        }

        //GridSystem Exposed
        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return gridSystem.GetGridObject(gridPosition);
        }
        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return gridSystem.GetWorldPosition(gridPosition);
        }
        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return gridSystem.GetGridPosition(worldPosition);
        }
        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            return gridSystem.isValidGridPosition(gridPosition);
        }
        public List<GridPosition> GetAllGridPositions()
        {
            return gridSystem.GetAllGridPositions();
        }
        public float GetGridCellSize()
        {
            return gridSystem.GetGridCellSize();
        }
    }
}

