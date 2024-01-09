using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class MouseWorld : MonoBehaviour
    {
        Camera mainCameraReference;
        private void Start()
        {
             mainCameraReference = Camera.main;
        }
        // Update is called once per frame
        void Update()
        {
            Ray ray = mainCameraReference.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit));
            transform.position = raycastHit.point;
        }
    }
}

