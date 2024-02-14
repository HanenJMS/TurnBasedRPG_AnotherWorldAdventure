using JetBrains.Annotations;
using System.Collections;
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


        public GAction GetCurrentAction() => currentAction;
        public bool HasCurrentAction() => currentAction != null;
        public bool HasCurrentActionRunning() => currentAction.IsRunning() && HasCurrentAction();
        /// <summary>
        /// can return null
        /// </summary>
        /// <param name="action"></param>
        public void SetCurrentAction(GAction action) => currentAction = action;
        public List<GAction> GetActions() => actions;

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
