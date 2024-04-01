using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.UnitSystem;
using System;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.ControllerSystem
{
    public class UnitActionSystem : MonoBehaviour
    {
        public static UnitActionSystem Instance { get; private set; } 
        [SerializeField] Unit selectedUnit;
        [SerializeField] LayerMask unitLayerMask;
        BaseAction selectedAction;
        public Action onSelectedUnit;
        public Action onSelectedAction;
        public Action onActionExecuted;
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
        private void Start()
        {
            selectedAction = selectedUnit.GetActionHandler().GetAction<MoveAction>();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;
            }
            if(Input.GetMouseButtonDown(1))
            {
                if(TryHandleSelectedAction()) return;
            }
        }
        bool TryHandleUnitSelection()
        {
            RaycastHit hit = MouseWorld.GetRaycastHitLayered(unitLayerMask);
            if (hit.transform == null) return false;
            if (!hit.transform.TryGetComponent<Unit>(out Unit unit)) return false;
            if (unit.GetFactionHandler().GetFactionName() != "Player") return false;
            SetSelectedUnit(unit);
            return true;
        }
        private bool TryHandleSelectedAction()
        {
            object hit = MouseWorld.GetRaycastHit();
            if (hit == null) hit = MouseWorld.GetMousePosition();
            Debug.Log(hit.ToString());
            if (selectedAction == null) return false;
            if (!selectedAction.CanExecuteOnTarget(hit)) return false;
            if (!selectedUnit.GetActionHandler().HasEnoughActionPoints(selectedAction)) return false;
            if (selectedAction.IsOnCooldown()) return false;
            selectedAction.SetTarget(hit);
            selectedAction.ExecuteAction();
            onActionExecuted?.Invoke();
            return true;
                
        }

        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }
        public BaseAction GetSelectedAction()
        {
            return selectedAction;
        }
        public void SetSelectedAction(BaseAction selectedAction)
        {
            this.selectedAction = selectedAction;
            onSelectedAction?.Invoke();
        }

        void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            selectedAction = selectedUnit.GetActionHandler().GetAction<MoveAction>();
            onSelectedUnit?.Invoke();
        }
    }
}

