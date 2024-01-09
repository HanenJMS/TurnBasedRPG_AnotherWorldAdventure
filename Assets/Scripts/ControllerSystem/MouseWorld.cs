using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class MouseWorld : MonoBehaviour
    {
        private static MouseWorld instance;

        static Camera mainCameraReference;
        [SerializeField] LayerMask mousePlaneLayer;
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(this);
            }
            instance = this;
        }
        private void Start()
        {
             mainCameraReference = Camera.main;
        }
        // Update is called once per frame
        void Update()
        {
            transform.position = GetMousePosition();
        }
        public static Vector3 GetMousePosition()
        {
            Ray ray = mainCameraReference.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayer);
            return raycastHit.point;
        }
    }
}

