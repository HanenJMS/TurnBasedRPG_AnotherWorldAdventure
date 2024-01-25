using AnotherWorldProject.ActionSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem
{
    public enum AiStates
    {
        Attack, Guard, Patrol
    }
    public abstract class AIStateMachine : MonoBehaviour
    {
        [SerializeField] protected string StateName = "BaseState";
        protected bool isActive = false;
        protected bool isTriggered = false;
        protected AIHandler aiHandler;
        BaseAction currentAction;
        protected virtual void Awake()
        {
            aiHandler = GetComponentInParent<AIHandler>();
            isTriggered = false;
        }
        protected virtual void Update()
        {
            if (!isActive)
            {
                Cancel();
                return;
            }
        }
        protected void StartState()
        {

            isActive = true;
            aiHandler.SetCurrentState(this);
        }
        protected void EndState()
        {
            aiHandler.Cancel();
        }
        public abstract void RunStateBehavior();
        public BaseAction GetCurrentAction()
        {
            return currentAction;
        }
        public virtual bool IsRunning()
        {
            return isActive;
        }
        public virtual void Cancel()
        {
            isActive = false;
        }
        public override string ToString()
        {
            return this.StateName;
        }

    }
}

