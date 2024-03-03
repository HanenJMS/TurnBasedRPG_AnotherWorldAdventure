using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.EquipmentSystem
{
    public enum EquipmentType
    {
        Head, Armor, Hand
    }
    public class Equipment : MonoBehaviour
    {
        [SerializeField] EquipmentType equipmentType;
    }
}

