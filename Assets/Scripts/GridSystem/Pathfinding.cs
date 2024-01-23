using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.GridSystem
{
    public class Pathfinding : MonoBehaviour
    {
        [SerializeField] private Transform gridDebugObject;
        GridSystem<PathNode> gridSystem;
        [SerializeField]int width, height;
        [SerializeField]float cellSize;
        private void Awake()
        {
            gridSystem = new GridSystem<PathNode>(width, height, cellSize, (GridSystem<PathNode> g, GridPosition gp) => new PathNode(gp));
            gridSystem.CreateDebugObject(gridDebugObject);


        }
    }
}

