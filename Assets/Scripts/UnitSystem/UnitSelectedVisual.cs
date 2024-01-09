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
            UnitActionSystem.instance.onSelectedUnit += OnSelectedUnit;
            UpdateVisual();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnSelectedUnit()
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (UnitActionSystem.instance.GetSelectedUnit() == null) return;
            meshRenderer.enabled = (UnitActionSystem.instance.GetSelectedUnit() == unit);
        }
    }
}

