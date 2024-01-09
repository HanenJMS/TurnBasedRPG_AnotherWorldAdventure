using AnotherWorldProject.GridSystem;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class TestingGrid : MonoBehaviour
    {
        [SerializeField] Transform debugObject;
        GridSystem gridSystem;
        // Start is called before the first frame update
        void Start()
        {
            gridSystem = new GridSystem(10, 10, 2);
            gridSystem.CreateDebugObject(debugObject);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

