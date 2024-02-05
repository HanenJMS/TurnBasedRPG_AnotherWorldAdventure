using AnotherWorldProject.AISystem.GOAP.Core;
using AnotherWorldProject.ControllerSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.UI
{
    public class GoapVisualUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI GWorldStateText;
        [SerializeField] TextMeshProUGUI GWorldInventoryText;
        [SerializeField] TextMeshProUGUI unitInventory;
        [SerializeField] TextMeshProUGUI unitStateText;
        [SerializeField] TextMeshProUGUI unitgoalStateText;
        GAgent unit;
        private void Start()
        {
            UnitActionSystem.Instance.onSelectedUnit += UpdateUnit;
            UpdateUnit();
        }
        private void Update()
        {
            UpdateGWorldStateText();
            UpdateGWorldInventoryText();
            UpdateSelectedUnitInventory();
            UpdateSelectedUnitStateText();
            UpdateUnitCurrentGoalState();
        }
        void UpdateUnit()
        {
            unit = UnitActionSystem.Instance.GetSelectedUnit().gameObject.GetComponent<GAgent>();
        }
        void UpdateSelectedUnitInventory()
        {
            unitInventory.text = "Unit inventory state" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, Queue<GameObject>> states in unit.gameObject.GetComponent<GAgent>().GetInventory().GetInventory())
                {
                    unitInventory.text += states.Key + " " + states.Value.Count + "\n";
                }
            }
        }
        void UpdateSelectedUnitStateText()
        {
            unitStateText.text = "unit states" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, int> states in unit.gameObject.GetComponent<GAgent>().GetAgentStates().GetStates())
                {
                    unitStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        private void UpdateUnitCurrentGoalState()
        {
            unitgoalStateText.text = "UnitGoal States" + "\n";
            if (unit != null)
            {
                if (unit.gameObject.GetComponent<GAgent>().GetCurrentGoal().goalState == null) return;
                foreach (KeyValuePair<string, int> states in unit.gameObject.GetComponent<GAgent>().GetCurrentGoal().goalState)
                {
                    unitgoalStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        private void UpdateGWorldStateText()
        {
            GWorldStateText.text = "Gworld States" + "\n";
            if (GWorld.Instance.GetGWorldWorldStates().GetStates() != null)
            {
                foreach (KeyValuePair<string, int> states in GWorld.Instance.GetGWorldWorldStates().GetStates())
                {
                    GWorldStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        void UpdateGWorldInventoryText()
        {
            GWorldInventoryText.text = "Gworld Inventory state" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, Queue<GameObject>> states in GWorld.Instance.GetWorldInventory().GetInventory())
                {
                    GWorldInventoryText.text += states.Key + " " + states.Value.Count + "\n";
                }
            }
        }
    }
}
