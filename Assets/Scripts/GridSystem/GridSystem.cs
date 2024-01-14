
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class GridSystem
    {
        int width, height;
        float cellSize;
        Dictionary<GridPosition, GridObject> grid;
        List<GridPosition> allGridPositions;
        public GridSystem(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.grid = new Dictionary<GridPosition, GridObject>();
            this.allGridPositions = new();
            for (int x = 0; x < width; x++)
            {
                for(int z = 0; z< height; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    GridObject newObject = new GridObject(this, gridPosition);
                    grid.Add(gridPosition, newObject);
                    allGridPositions.Add(gridPosition);
                }
            }
        }
        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
        }
        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize),
                 Mathf.RoundToInt(worldPosition.z / cellSize));
        }
        public void CreateDebugObject(Transform debugPrefab)
        {
            foreach(KeyValuePair<GridPosition, GridObject> gridPosition in grid)
            {
                Transform debugobject = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition.Key), Quaternion.identity);
                GridDebugObject gridDebugObject = debugobject.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(gridPosition.Value);
            }
        }
        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return grid[gridPosition];
        }
        public bool isValidGridPosition(GridPosition gridPosition)
        {
            return gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height;
        }
        public List<GridPosition> GetAllGridPositions()
        {
            return allGridPositions;
        }
        public float GetGridCellSize()
        {
            return cellSize;
        }
    }

}
