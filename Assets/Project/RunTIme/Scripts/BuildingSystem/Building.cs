using AnotherWorldProject.GridSystem;
using UnityEngine;

namespace AnotherWorldProject.BuildingSystem
{
    public class Building : MonoBehaviour
    {
        GridPosition currentPosition;
        private void Start()
        {
            currentPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
        }
        public void Use()
        {

        }
        public void Demolish()
        {
            GridObject gridObject = LevelGridSystem.Instance.GetGridObject(currentPosition);
            gridObject.RemoveObjectFromGrid(this.gameObject);
            gridObject.SetIsBlocked(false);
            Destroy(this.gameObject);
        }


    }
}

