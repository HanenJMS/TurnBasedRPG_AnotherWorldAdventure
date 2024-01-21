using AnotherWorldProject.ControllerSystem;
using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class UnitSelectedVisual : MonoBehaviour
    {
        Unit unit;
        MeshRenderer meshRenderer;
        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            unit = GetComponentInParent<Unit>();
        }
        void Start()
        {
            UnitActionSystem.Instance.onSelectedUnit += OnSelectedUnit;
            UpdateVisual();
        }
        void OnSelectedUnit()
        {
            UpdateVisual();
        }
        private void UpdateVisual()
        {
            if (UnitActionSystem.Instance.GetSelectedUnit() == null) return;
            meshRenderer.enabled = (UnitActionSystem.Instance.GetSelectedUnit() == unit);
        }
        private void OnDestroy()
        {
            UnitActionSystem.Instance.onSelectedUnit -= OnSelectedUnit;
        }
    }
}

