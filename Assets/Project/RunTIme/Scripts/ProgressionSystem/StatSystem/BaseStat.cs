using UnityEngine;

namespace AnotherWorldProject.ProgressionSystem.StatSystem
{
    public class BaseStat : MonoBehaviour
    {
        [Range(1, 99)]
        [SerializeField] int level = 1;
        [SerializeField] StatType statType;
    }
}

