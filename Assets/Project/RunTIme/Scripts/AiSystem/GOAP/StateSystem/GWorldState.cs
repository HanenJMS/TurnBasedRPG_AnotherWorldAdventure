using System;

namespace AnotherWorldProject.AISystem.GOAP.StateSystem
{
    [System.Serializable]
    public struct GWorldState : IEquatable<GWorldState>
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
            return HashCode.Combine(key, key);
        }

        public bool Equals(GWorldState other)
        {
            return other.key == key;
        }

        public static bool operator ==(GWorldState a, GWorldState b)
        {
            return a.key == b.key;
        }
        public static bool operator !=(GWorldState a, GWorldState b)
        {
            return a.key != b.key;
        }
        public static GWorldState operator +(GWorldState a, GWorldState b)
        {
            return new(a.key, a.value + b.value);
        }
        public static GWorldState operator -(GWorldState a, GWorldState b)
        {
            return new(a.key, a.value - b.value);
        }
    }

}
