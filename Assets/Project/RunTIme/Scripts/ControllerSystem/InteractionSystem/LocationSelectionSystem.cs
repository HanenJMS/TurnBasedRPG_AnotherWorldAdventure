using AnotherWorldProject.AISystem.GOAP;
using System;
using UnityEngine;
namespace AnotherWorldProject.ControllerSystem
{
    public class LocationSelectionSystem : MonoBehaviour
    {
        public static LocationSelectionSystem Instance { get; private set; }
        [SerializeField] GLocation selectedLocation;
        [SerializeField] LayerMask LocationLayer;
        public Action onSelectedLocation;
        // Update is called once per frame

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleLocationSelection()) return;
            }
        }

        private bool TryHandleLocationSelection()
        {
            RaycastHit hit = MouseWorld.GetRaycastHit(LocationLayer);
            if (hit.transform == null) return false;
            if (hit.transform.TryGetComponent<GLocation>(out GLocation location))
            {
                SetSelectedLocation(location);
                return true;
            }
            return false;
        }

        private void SetSelectedLocation(GLocation location)
        {
            selectedLocation = location;
            onSelectedLocation?.Invoke();
        }
        public GLocation GetSelectedLocation()
        {
            return selectedLocation;
        }
    }
}

