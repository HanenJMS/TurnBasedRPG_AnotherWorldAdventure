
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
        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * cellSize;
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
                    Transform debugobject = GameObject.Instantiate(debugPrefab, GetWorldPosition(x, z), Quaternion.identity);
                    
                }
            }
        }
    }

}
