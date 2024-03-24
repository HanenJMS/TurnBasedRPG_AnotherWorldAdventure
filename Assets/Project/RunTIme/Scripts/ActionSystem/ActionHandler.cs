using AnotherWorldProject.ControllerSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class ActionHandler : MonoBehaviour
    {
        BaseAction currentAction;
        BaseAction nextAction;
        List<BaseAction> equippedActions = new();
        BaseAction[] actions;
        [SerializeField] int MaxActionPoints = 100;
        [SerializeField] int currentActionPoints;
        [SerializeField] int restorePointsPerTurn = 1;
        private void Awake()
        {
            actions = GetComponents<BaseAction>();
            currentActionPoints = MaxActionPoints;
            
        }
        private void Start()
        {
            TurnSystem.Instance.onTimerChanged += RestoreActionPoints;
        }
        private void OnDestroy()
        {
            TurnSystem.Instance.onTimerChanged -= RestoreActionPoints;
        }
        public BaseAction[] GetAllActions()
        {
            return actions;
        }

        public void EquipAction(BaseAction action, int index)
        {
            equippedActions[index] = action;
        }
        public T GetAction<T>() where T : BaseAction
        {
            foreach(BaseAction baseAction in actions)
            {
                if(baseAction is T)
                    return baseAction as T;
            }
            return null;
        }
        public void StartAction(BaseAction action)
        {
            if (currentAction != null)
            {
                Cancel();
            }
            currentAction = action;
        }
        public void SetCurrentAction(BaseAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                Cancel();
            }
            currentAction = action;

        }
        public bool IsRunningAction()
        {
            if (currentAction == null) return false;
            return currentAction.IsRunning();
        }
        public bool HasEnoughActionPoints(BaseAction action)
        {
            return currentActionPoints >= action.GetActionCost();
        }
        public void UseActionPoints(BaseAction action)
        {
            currentActionPoints -= action.GetActionCost();
        }
        public int GetCurrentActionPoints()
        {
            return currentActionPoints;
        }
        public void Cancel()
        {
            if (currentAction == null) return;
            currentAction.Cancel();
            currentAction = null;
        }
        public void RestoreActionPoints()
        {
            if (currentActionPoints >= MaxActionPoints) return;
            Mathf.Clamp(currentActionPoints += restorePointsPerTurn, 0, MaxActionPoints);
        }

    }
}

