using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace AnotherWorldProject.UI_System
{
    public class QuestionDialogUI : MonoBehaviour
    {
        [SerializeField] Button yesButton;
        [SerializeField] Button noButton;
        [SerializeField] TextMeshProUGUI textMessage;
        public static QuestionDialogUI Instance { get; private set; }
        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;

        }
    }
}

