using AnotherWorldProject.ControllerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnotherWorldProject.ActionSystem
{
    public class ActionButtonUI : MonoBehaviour
    {
        BaseAction action;
        Button button;
        string actionName;
        TextMeshProUGUI nameText;
        [SerializeField] GameObject selectedActionVisual;
        private void Awake()
        {
            button = GetComponent<Button>();
            nameText = GetComponentInChildren<TextMeshProUGUI>();
        }
        private void Start()
        {
            UpdateSelectedVisual();
        }
        public void SetAction(BaseAction action)
        {
            this.action = action;
            actionName = action.ToString();
            nameText.text = actionName;
            button.onClick.AddListener(() =>
            {
                UnitActionSystem.Instance.SetSelectedAction(action);
            });
        }
        public void UpdateSelectedVisual()
        {
            selectedActionVisual.SetActive(UnitActionSystem.Instance.GetSelectedAction() == this.action);
        }
        public override string ToString()
        {
            return actionName;
        }
    }
}

