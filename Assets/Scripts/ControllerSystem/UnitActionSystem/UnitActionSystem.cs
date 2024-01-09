using AnotherWorldProject.UnitSystem;
using UnityEngine;
namespace AnotherWorldProject.ControllerSystem
{
    public class UnitActionSystem : MonoBehaviour
    {
        [SerializeField] Unit selectedUnit;
        [SerializeField] LayerMask unitLayerMask;
        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;
                selectedUnit.Move(MouseWorld.GetMousePosition());
            }
        }
        bool TryHandleUnitSelection()
        {
            RaycastHit hit = MouseWorld.GetRaycastHit(unitLayerMask);
            if (hit.transform == null) return false;
            if (hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                selectedUnit = unit;
                return true;
            }
            return false;
        }
    }
}

