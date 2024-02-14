using AnotherWorldProject.AISystem.GOAP.StateSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new();
        static GWorldStateHandler GWorldWorldStates;
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
        public GWorldStateHandler GetGWorldWorldStates()
        {
            return GWorldWorldStates;
        }
        
        public GameObject SearchWorldForItem(string item)
        {
            if (!inventory.HasItem(item)) return null;
            return inventory.GetItem(item);
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

