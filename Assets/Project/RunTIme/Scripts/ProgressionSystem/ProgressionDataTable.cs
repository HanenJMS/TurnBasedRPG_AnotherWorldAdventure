using AnotherWorldProject.ProgressionSystem.StatSystem;
using UnityEngine;

namespace AnotherWorldProject.ProgressionSystem
{
    [System.Serializable]
    public class ProgressionDataTable
    {
        [SerializeField] TalentType progressionType;
        [SerializeField] int[] experienceToThreshhold;
    }
}

