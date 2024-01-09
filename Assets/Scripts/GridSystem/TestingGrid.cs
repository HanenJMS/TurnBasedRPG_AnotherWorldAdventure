using AnotherWorldProject.GridSystem;
using UnityEngine;

namespace AnotherWorldProject.GridSystem
{
    public class TestingGrid : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            new GridSystem(10, 10, 2);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

