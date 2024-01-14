using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class TurnSystemUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI turnNumber;

        private void Start()
        {
            TurnSystem.Instance.onTimerChanged += TurnNumberVisual;
        }
        void TurnNumberVisual()
        {
            turnNumber.text =$"Time: {TurnSystem.Instance.GetTurnNumber()}";
        }
    }
}

