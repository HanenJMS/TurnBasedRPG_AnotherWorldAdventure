using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GActionHandler : MonoBehaviour
    {
        [SerializeField] List<GAction> agentActionList;

        void Start()
        {
            agentActionList = new List<GAction>(this.GetComponents<GAction>());
        }

        void Update()
        {

        }
    }

}
