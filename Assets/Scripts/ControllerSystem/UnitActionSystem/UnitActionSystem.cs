using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System;
using UnityEngine;
namespace AnotherWorldProject.ControllerSystem
{
    public class UnitActionSystem : MonoBehaviour
    {
        public static UnitActionSystem instance { get; set; } 
        [SerializeField] Unit selectedUnit;
        [SerializeField] LayerMask unitLayerMask;
        public Action onSelectedUnit;
        // Update is called once per frame

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;

                GridPosition mousePosition = LevelGridSystem.Instance.GetGridPosition(MouseWorld.GetMousePosition());
                if(LevelGridSystem.Instance.IsValidGridPosition(mousePosition))
                {
                    if(selectedUnit.GetMoveAction().IsValidActionOnGridPosition(mousePosition))
                    {
                        selectedUnit.GetMoveAction().Move(mousePosition);
                    }
                }
            }
        }
        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }
        bool TryHandleUnitSelection()
        {
            RaycastHit hit = MouseWorld.GetRaycastHit(unitLayerMask);
            if (hit.transform == null) return false;
            if (hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
            return false;
        }
        void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            onSelectedUnit?.Invoke();
        }
    }
}

