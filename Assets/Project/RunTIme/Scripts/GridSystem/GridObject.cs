using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class GridObject
    {
        GridSystem<GridObject> gridSystem;
        GridPosition gridPosition;
        List<object> objectList;
        bool isBlocked;
        public GridObject(GridSystem<GridObject> gridSystem, GridPosition gridPosition)        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
            objectList = new();
            isBlocked = false;
        }
        public void AddObjectToGrid(object gridObject)
        {
            objectList.Add(gridObject);
        }
        public void RemoveObjectFromGrid(object gridObject)
        {
            objectList.Remove(gridObject);
        }
        public bool HasObjectOnGrid()
        {
            return objectList.Count > 0;  
        }
        public bool GetIsBlocked()
        {
            return isBlocked;
        }
        public void SetIsBlocked(bool isBlocked)
        {
            this.isBlocked = isBlocked;
        }
        public void SetObjectPriorityOnGrid(object newGridResident, int index)
        {
            if(objectList.Contains(newGridResident))
            {
                objectList.Remove(newGridResident);
            }
            objectList.Insert(index, newGridResident);
        }
        public List<object> GetObjectList()
        {
            return objectList;
        }
        public override string ToString()
        {
            string unitOnGrid = "";
            foreach(object unit in objectList)
            {
                if(unit is Unit)
                {
                    unitOnGrid += (unit as Unit).gameObject.name + "\n";
                }
            }
            return gridPosition.ToString() + $"\n{unitOnGrid}";
        }
    }
}

