using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GLocation : MonoBehaviour
    {
        [SerializeField] string locationName;
        [SerializeField] string locationState;
        void Start()
        {
            if (locationName == "") return;
            GWorld.Instance.GetWorldLocations().AddLocation(locationName, this.transform.gameObject);
            if (locationState == "") return;
            GWorld.Instance.GetGWorldWorldStates().ModifyState(new(locationState, 1));
        }

    }

}
