using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GWorldStates
    {
        Dictionary<string, int> states;

        public GWorldStates() 
        {
            states = new();
        }

        public bool ContainsState(string state)
        {
            return states.ContainsKey(state);
        }
        public void ModifyState(string state, int value)
        {
            if(states.ContainsKey(state))
            {
                states[state] += value;
                if (states[state] <= 0)
                {
                    RemoveState(state);
                }
                return;
            }
            AddState(state, value);
        }
        void AddState(string state, int value)
        {
            states.Add(state, value);
        }
        void RemoveState(string state)
        {
            if(states.ContainsKey(state))
            {
                states.Remove(state);
            }
        }
        public void SetState(string state, int value)
        {
            if( states.ContainsKey(state))
            {
                states[state] = value;
                return;
            }
            AddState(state, value);
        }
        public Dictionary<string, int> GetStates()
        {
            return states;
        }
    }

}
