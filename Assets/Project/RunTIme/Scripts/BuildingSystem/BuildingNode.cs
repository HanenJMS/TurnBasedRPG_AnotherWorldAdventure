using AnotherWorldProject.GridSystem;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingNode : MonoBehaviour
    {
        GridPosition gridPosition;
        Building placedBuilding;
        public BuildingNode(GridPosition gridPosition)
        {
            this.gridPosition = gridPosition;
        }

        public bool HasBuilding() => placedBuilding != null;
    }
}

