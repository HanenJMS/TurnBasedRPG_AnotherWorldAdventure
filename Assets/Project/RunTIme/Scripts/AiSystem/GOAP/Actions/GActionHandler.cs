using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.FactionSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP
{
    public class GActionHandler : MonoBehaviour
    {
        [SerializeField] List<GAction> actions;
        GAction currentAction;
        Queue<GAction> actionsPlanned;
        bool invoked = false;
        void Start()
        {
            actions = new List<GAction>(this.GetComponents<GAction>());
        }
        public bool HasPlannedActionsNotFinished()
        {
            return GetPlannedActions() != null && GetPlannedActions().Count > 0; ;
        }
        public bool HasPlannedActionsFinished()
        {
            return GetPlannedActions() != null && GetPlannedActions().Count == 0;
        }
        public void HandleCurrentAction()
        {
            if (GetCurrentAction().PreActionExecute())
            {
                if (GetCurrentAction().HasTarget())
                {
                    GetCurrentAction().ExecuteAction();
                }
            }
            else
            {
                SetPlannedActions(null);
            }
        }
        public void StartNextPlannedAction()
        {
            currentAction = actionsPlanned.Dequeue();
        }
        public void SetPlannedActions(Queue<GAction> actionsPlanned)
        {
            this.actionsPlanned = actionsPlanned;
        }
        public Queue<GAction> GetPlannedActions()
        {
            return actionsPlanned;
        }

        public GAction GetCurrentAction()
        {
            return currentAction;
        }

        public bool HasCurrentAction()
        {
            return currentAction != null;
        }

        public bool HasCurrentActionRunning()
        {
            if (!HasCurrentAction()) return false;
            return currentAction.IsRunning();
        }

        public void SetCurrentAction(GAction action)
        {
            currentAction = action;
        }

        public List<GAction> GetActions()
        {
            return actions;
        }

        public void InvokeComplete()
        {
            if (!invoked)
            {
                Invoke("CompleteAction", currentAction.GetDuration());
                invoked = true;
            }
        }

        void CompleteAction()
        {
            currentAction.CancelAction();
            currentAction.PostActionExecute();
            currentAction = null;
            invoked = false;
        }
    }

}
