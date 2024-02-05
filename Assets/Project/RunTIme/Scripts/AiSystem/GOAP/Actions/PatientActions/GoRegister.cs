namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoRegister : GAction
    {
        
        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("hasRegistered", 1))) return false;
            target = GetWorldLocation("Registration");
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("notRegistered", -1));
            agentStates.ModifyState(new("hasRegistered", 1));
            return true;
        }
    }
}
