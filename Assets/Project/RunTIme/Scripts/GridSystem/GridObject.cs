using AnotherWorldProject.UnitSystem;
using System.Collections.Generic;

namespace AnotherWorldProject.GridSystem
{
    public class GridObject
    {
        GridSystem<GridObject> gridSystem;
        GridPosition gridPosition;
        List<Unit> unitList;
        public GridObject(GridSystem<GridObject> gridSystem, GridPosition gridPosition)        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
            unitList = new();
        }
        public void AddUnit(Unit unit)
        {
            unitList.Add(unit);
        }
        public void RemoveUnit(Unit unit)
        {
            unitList.Remove(unit);
        }
        public bool Hasunits()
        {
            return unitList.Count > 0;  
        }
        public List<Unit> GetUnitList()
        {
            return unitList;
        }
        public override string ToString()
        {
            string unitOnGrid = "";
            foreach(Unit unit in unitList)
            {
                unitOnGrid += unit.name + "\n";
            }
            return gridPosition.ToString() + $"\n{unitOnGrid}";
        }
    }
}

