using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class GridObject
    {
        GridSystem gridSystem;
        GridPosition gridPosition;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
        }

    }
}

