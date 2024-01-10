
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
        public GridSystem(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.grid = new Dictionary<GridPosition, GridObject>();
            for (int x = 0; x < width; x++)
            {
                for(int z = 0; z< height; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    GridObject newObject = new GridObject(this, gridPosition);
                    grid.Add(gridPosition, newObject);
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
            for(int x = 0; x < width;x++)
            {
                for(int z = 0; z< height; z++)
                {
                    GridPosition gridPosition = new(x, z);
                    Transform debugobject = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                    GridDebugObject gridDebugObject = debugobject.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                }
            }
        }
        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return grid[gridPosition];
        }
    }

}
