namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new();
        static GWorldStates GWorldWorldStates;
        static GInventory inventory;
        static GWorldLocations worldLocations;
        static GWorld()
        {
            GWorldWorldStates = new();
            inventory = new();
            worldLocations = new();
        }
        private GWorld()
        {

        }


        public static GWorld Instance => instance;
        public GWorldStates GetGWorldWorldStates()
        {
            return GWorldWorldStates;
        }
        public GWorldLocations GetWorldLocations()
        {
            return worldLocations;
        }
        public GInventory GetWorldInventory()
        {
            return inventory;
        }

        //Testing Code

    }
}

