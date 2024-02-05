namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoHome : GAction
    {
        public override bool PreActionExecute()
        {
            if (!agentStates.ContainsState(new("isTreated", 1))) return false;
            target = GetWorldLocation("Home");
            if (target == null) return false;
            return true;
        }
        public override bool PostActionExecute()
        {
            GetWorldInventory().AddInventoryItem("Home", target);
            return true;
        }


    }
}
