namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToCubicle : GAction
    {

        public override bool PreActionExecute()
        {

            target = this.GetComponent<GAgent>().GetInventory().GetItem("Cubicle");
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {

            // Add a new state "TreatingPatient"
            GWorld.Instance.GetGWorldWorldStates().ModifyState(new("TreatingPatient", 1));
            // Give back the cubicle
            GWorld.Instance.GetWorldInventory().AddItem("Cubicle", target);
            // Give the cubicle back to the world
            GWorld.Instance.GetGWorldWorldStates().ModifyState(new("FreeCubicle", 1));
            return true;
        }
    }
}

