using TMPro;
using UnityEngine;
namespace AnotherWorldProject.GridSystem
{
    public class GridDebugObject : MonoBehaviour
    {
        GridObject gridObject;
        [SerializeField] TextMeshPro text;
        public void SetGridObject(GridObject gridObject)
        {
            this.gridObject = gridObject;
        }
        private void Update()
        {
            text.text = gridObject.ToString();
        }
    }
}

