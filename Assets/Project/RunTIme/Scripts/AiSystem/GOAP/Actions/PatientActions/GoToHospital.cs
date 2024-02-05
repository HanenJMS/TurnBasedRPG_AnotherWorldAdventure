namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToHospital : GAction
    {
        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("atHospital", 1))) return false;
            target = GetWorldLocation("Hospital");
            if (target == null) return false;
            return true;
        }
        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("atHospital", 1));
            agentStates.ModifyState(new("notRegistered", 1));
            return true;
        }


    }
}
