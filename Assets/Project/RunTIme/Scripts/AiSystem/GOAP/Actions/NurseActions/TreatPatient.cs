namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class TreatPatient : GAction
    {
        public override bool PreActionExecute()
        {
            if (!agentStates.ContainsState(new("atWork", 1))) return false;
            GetTargetAgent(this.gameObject).GetGoalHandler().GetGoals()[new("treatPatient")] = 
                inventory.
                GetItem("WorkLocation").
                GetComponent<GLocation>().
                GetStateHandler().
                GetStates()["JobWaiting"];
            target = inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetInventory().GetItem("JobWaiting");
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetStateHandler().ModifyState(new("JobWaiting", -1));
            GAgent target = GetTargetAgent(this.target);
            target.GetStateHandler().ModifyState(new("isSick", -1));
            target.GetStateHandler().ModifyState(new("isTreated", 1));
            return true;
        }
    }
}

