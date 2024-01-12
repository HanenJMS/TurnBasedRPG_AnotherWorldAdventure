using AnotherWorldProject.ControllerSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
                UnitActionSystem.instance.SetSelectedAction(action);
            });
        }
        public void UpdateSelectedVisual()
        {
            selectedActionVisual.SetActive(UnitActionSystem.instance.GetSelectedAction() == this.action);
        }
        public override string ToString()
        {
            return actionName;
        }
    }
}

