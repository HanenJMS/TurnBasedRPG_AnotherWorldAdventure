using System.Collections.Generic;

namespace AnotherWorldProject.AISystem.GOAP.StateSystem
{
    public class GWorldStateHandler
    {
        Dictionary<string, int> states;

        public GWorldStateHandler()
        {
            states = new();
        }

        public bool ContainsState(GWorldState state)
        {

            return states.ContainsKey(state.key);
        }
        public void ModifyState(GWorldState state)
        {
            if (states.ContainsKey(state.key))
            {
                states[state.key] += state.value;
                if (states[state.key] <= 0)
                {
                    RemoveState(state.key);
                }
                return;
            }
            AddState(state);
        }
        void AddState(GWorldState state)
        {
            states.Add(state.key, state.value);
        }
        void RemoveState(string state)
        {
            if (states.ContainsKey(state))
            {
                states.Remove(state);
            }
        }
        public void SetState(GWorldState state)
        {
            if (states.ContainsKey(state.key))
            {
                states[state.key] = state.value;
                return;
            }
            AddState(state);
        }
        public Dictionary<string, int> GetStates()
        {
            return states;
        }
    }

}
