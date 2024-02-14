using AnotherWorldProject.AISystem.GOAP.Core;
using AnotherWorldProject.AISystem.GOAP.StateSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    [CreateAssetMenu(fileName = "GOAPActionReference", menuName = "GOAP/Action Reference")]
    public class GOAPActionReference : ScriptableObject
    {
        public GWorldState[] actions;
    }

}
