using UnityEngine;
namespace AnotherWorldProject.ProgressionSystem
{
    [CreateAssetMenu(fileName = "Progressiont Table", menuName = "ProgressionSystem/Progresstion Table", order = 0)]
    public class ProgressionData : ScriptableObject
    {
        [SerializeField] ProgressionDataTable[] progressionTable = null;
    }
}

