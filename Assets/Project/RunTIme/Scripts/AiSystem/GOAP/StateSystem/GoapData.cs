using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    [CreateAssetMenu(fileName = "GoapDefinition", menuName = "GoapSystem/GoalAndStateRelationDefinitions")]
    public class GoapData : ScriptableObject
    {
        [SerializeField] List<GoapDefinitions> goapDefinitions = new List<GoapDefinitions>();
    }
}

