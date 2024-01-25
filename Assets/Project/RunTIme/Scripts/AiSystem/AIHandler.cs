using AnotherWorldProject.UnitSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem
{
    public class AIHandler : MonoBehaviour
    {
        AIStateMachine currentState;
        AIDetection detector;
        PatrolState defaultState;
        public bool isRunning = false;
        public Action onStateChange;
        Unit aiUnit;
        private void Awake()
        {
            detector = GetComponentInChildren<AIDetection>();
            defaultState = GetComponentInChildren<PatrolState>();
            aiUnit = GetComponent<Unit>();
        }
        private void Start()
        {
            detector.onAIbehaviorTriggered += SetGuardState;
        }
        private void Update()
        {
            if (currentState != null)
            {
                currentState.RunStateBehavior();
            }
        }
        public void SetGuardState()
        {
            SetCurrentState(this.gameObject.GetComponentInChildren<AttackState>());
        }
        public void SetCurrentState(AIStateMachine state)
        {
            if (currentState == state) return;
            if (currentState != null)
            {
                Cancel();
            }
            currentState = state;

        }
        public void CurrentStateFailed()
        {
            SetCurrentState(defaultState);
        }
        public bool IsRunningState()
        {
            if (currentState == null) return false;
            return isRunning;
        }
        public List<Unit> GetDetectedUnitList()
        {
            return detector.GetDetectedUnitList();
        }
        public void RemoveUnitFromList(Unit unit)
        {
            detector.RemoveUnit(unit);
        }
        public AIStateMachine GetCurrentState()
        {
            return currentState;
        }
        public void Cancel()
        {
            if (currentState == null) return;
            currentState.Cancel();
            currentState = null;
        }

        public Unit GetAiUnit()
        {
            return aiUnit;
        }
        //Ai Actions

    }
}

