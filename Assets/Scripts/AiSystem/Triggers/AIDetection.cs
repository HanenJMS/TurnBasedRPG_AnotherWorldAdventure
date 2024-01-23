using AnotherWorldProject.UnitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnotherWorldProject.AISystem
{
    public class AIDetection : MonoBehaviour
    {
        [SerializeField] LayerMask unitLyaer;
        [SerializeField] float detectionRadius = 5f;
        [SerializeField]List<Unit> unitsDetectedList = new();
        Dictionary<Unit, float> unitDistanceList = new();
        public Action onAIbehaviorTriggered;
        bool isDetected = false;
        private void Update()
        {

        }

        public void AddUnitDetected(Unit unit)
        {
            if(!unitsDetectedList.Contains(unit))
            {
                unitsDetectedList.Add(unit);
                unitDistanceList.Add(unit, Vector3.Distance(this.transform.position, unit.transform.position));
                
            }
              
        }
        public void RemoveUnit(Unit unit)
        {
            if(unitsDetectedList.Contains(unit))
            {

                unitsDetectedList.Remove(unit);
            }
        }
        public List<Unit> GetDetectedUnitList()
        {
            foreach (Collider hit in Physics.OverlapSphere(this.transform.position, detectionRadius, unitLyaer.value))
            {
                if (hit.transform.TryGetComponent(out Unit unit))
                {
                    if (unit.GetHealthHandler().IsDead()) continue;

                    AddUnitDetected(unit);
                }
            }
            return unitsDetectedList;
        }
    }
}
