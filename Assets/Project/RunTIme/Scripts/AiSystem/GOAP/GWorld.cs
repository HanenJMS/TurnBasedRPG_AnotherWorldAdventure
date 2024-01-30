using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new();
        static GWorldStates world;
        static GWorld()
        {
            world = new();
        }
        private GWorld()
        {
            
        }

        public static GWorld Instance { get { return instance; } }
        public GWorldStates GetWorld()
        {
            return world;
        }
    }
}

