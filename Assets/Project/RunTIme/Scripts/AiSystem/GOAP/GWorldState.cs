using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    [System.Serializable]
    public struct GWorldState
    {
        public string key;
        public int value;
        public GWorldState(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
        public override bool Equals(object obj)
        {
            return obj is GWorldState worldState && worldState.key == key;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator == (GWorldState a, GWorldState b)
        {
            return a.key == b.key;
        }
        public static bool operator != (GWorldState a, GWorldState b)
        {
            return a.key != b.key;
        }
    }

}
