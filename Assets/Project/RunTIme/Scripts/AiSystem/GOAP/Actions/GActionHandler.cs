using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP
{
    public class GActionHandler : MonoBehaviour
    {
        [SerializeField] List<GAction> actions;
        GAction currentAction;
        bool invoked = false;
        void Start()
        {
            actions = new List<GAction>(this.GetComponents<GAction>());
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
