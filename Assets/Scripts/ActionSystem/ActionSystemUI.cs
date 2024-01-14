using AnotherWorldProject.ControllerSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace AnotherWorldProject.ActionSystem
{
    public class ActionSystemUI : MonoBehaviour
    {
        [SerializeField] GameObject actionButtonPrefab;
        [SerializeField] Transform actionUIContainer;
        [SerializeField] TextMeshProUGUI ActionPointText;
        List<BaseAction> actions = new();
        List<ActionButtonUI> buttons = new();
        private void Start()
        {
            UnitActionSystem.Instance.onSelectedUnit += ShowAvailableActions;
            UnitActionSystem.Instance.onSelectedAction += UpdateActionSelectedVisual;
            UnitActionSystem.Instance.onSelectedUnit += ActionPointVisual;
            UnitActionSystem.Instance.onActionExecuted += ActionPointVisual;
            TurnSystem.Instance.onTimerChanged += ActionPointVisual;
            ActionPointVisual();
        }
        private void Update()
        {

        }
        void ShowAvailableActions()
        {
            ClearButtonsUI();
            foreach (BaseAction action in UnitActionSystem.Instance.GetSelectedUnit().GetActionHandler().GetAllActions())
            {

                actions.Add(action);

                GameObject newActionButton = Instantiate(actionButtonPrefab, actionUIContainer);
                //TextMeshProUGUI actionName = newActionButton.GetComponentInChildren<TextMeshProUGUI>();
                //actionName.text = action.ToString();
                Button button = newActionButton.GetComponent<Button>();

                ActionButtonUI butttonUI = newActionButton.GetComponent<ActionButtonUI>();
                butttonUI.SetAction(action);
                buttons.Add(butttonUI);
            }

        }

        void ActionPointVisual()
        {
            ActionPointText.text = $"Action Points: {UnitActionSystem.Instance.GetSelectedUnit().GetActionHandler().GetCurrentActionPoints()}";
        }
        void UpdateActionSelectedVisual()
        {
            foreach (ActionButtonUI button in buttons)
            {
                button.UpdateSelectedVisual();
            }
        }
        void ClearButtonsUI()
        {
            foreach (ActionButtonUI button in buttons)
            {
                Destroy(button.gameObject);
            }
            actions.Clear();
            buttons.Clear();
        }
    }
}

