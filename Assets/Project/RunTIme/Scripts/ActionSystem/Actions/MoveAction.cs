using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.ActionSystem
{
    public class MoveAction : BaseAction
    {
        Vector3 targetPosition;

        NavMeshAgent agent;
        float speed = 0f;
        [SerializeField] int maxDistance = 2;
        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            UpdateAnimator();
            if (!isActive) return;
            
        }
        private void Start()
        {
            targetPosition = this.transform.position;

        }
        protected override void StartAnimation()
        {
            //animator.SetBool(ActionName, isActive);
        }
        protected override void ResetAnimationTrigger()
        {
            //animator.SetBool(ActionName, isActive);
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }
        public void MoveToWithinStoppingDistance(float stoppingDistance)
        {
            agent.stoppingDistance = stoppingDistance;
        }
        public bool GetIsInDistance()
        {
            return Vector3.Distance(targetPosition, this.transform.position) <= agent.stoppingDistance;
        }
        public int GetGridMaxDistance()
        {
            return maxDistance;
        }
        public override void Cancel()
        {
            base.Cancel();
        }

        public override void ExecuteAction()
        {
            StartAction();
            agent.SetDestination((Vector3)actionTarget);
        }

        public override void SetTarget(object actionTarget)
        {
            this.actionTarget = actionTarget;
        }

        public override bool CanExecuteOnTarget(object actionTarget)
        {
            return actionTarget is Vector3;
        }
    }
}

