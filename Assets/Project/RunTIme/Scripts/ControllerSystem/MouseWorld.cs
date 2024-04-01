using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class MouseWorld : MonoBehaviour
    {
        private static MouseWorld instance { get; set; }

        static Camera mainCameraReference;
        [SerializeField] LayerMask mousePlaneLayer;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
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
            RaycastHit hit = GetRaycastHitLayered(instance.mousePlaneLayer);
            return hit.point;
        }
        public static RaycastHit GetRaycastHitLayered(LayerMask layerMask)
        {
            Ray ray = mainCameraReference.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask);
            return raycastHit;
        }
        public static RaycastHit GetRaycastHit()
        {
            Ray ray = mainCameraReference.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue);
            return raycastHit;
        }
        public static T GetInteractionType<T>(RaycastHit hit) where T : MonoBehaviour
        {
            return hit.transform.GetComponent<T>();
        }
    }
}

