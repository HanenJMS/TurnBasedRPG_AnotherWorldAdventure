using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AnotherWorldProject.ActionSystem
{
    public class ActionHandler : MonoBehaviour
    {
        BaseAction currentAction;
        BaseAction[] actions;
        [SerializeField] int MaxActionPoints = 100;
        [SerializeField] int currentActionPoints;
        private void Awake()
        {
            actions = GetComponents<BaseAction>();
            currentActionPoints = MaxActionPoints;
        }
        public BaseAction[] GetAllActions()
        {
            return actions;
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
    }
}

