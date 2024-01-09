using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public struct GridPosition
    {
        public int x;
        public int z;

        public GridPosition(int x, int z)
        {
            this.x = x;
            this.z = z;
        }
        public override string ToString()
        {
            return $"({x}), ({z})";
        }
    }
}

