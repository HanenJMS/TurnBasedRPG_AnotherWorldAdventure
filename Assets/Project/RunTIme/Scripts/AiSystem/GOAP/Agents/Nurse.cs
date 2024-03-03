using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();
            Goal workingGoal = new("atWork", false);
            Goal goal2 = new Goal("treatPatient", false);
            Goal goal3 = new("rested", false);
            GetGoalHandler().GetGoals().Add(goal2, 0);
            GetGoalHandler().GetGoals().Add(goal3, 0);
            GetGoalHandler().GetGoals().Add(workingGoal, 5);
            GetStateHandler().ModifyState(new("goToWork", 1));


        }
        //private void OnEnable()
        //{
        //    AssignWorkLocation(GWorld.Instance.GetWorldLocations().GetLocation("Hospital"));
        //}
        public void AssignWorkLocation(GLocation workLocation)
        {
            if (workLocation == null) return;
            GetInventory().AddItem("WorkLocation", workLocation.gameObject);
        }
    }
}
