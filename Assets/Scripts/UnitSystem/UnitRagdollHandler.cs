using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.UnitSystem
{
    public class UnitRagdollHandler : MonoBehaviour
    {

        [SerializeField] Transform ragDollDeath;
        [SerializeField] Transform originalRootBoneTransform;

        public void Spawn()
        {
            Transform ragdollTransform = Instantiate(ragDollDeath, this.transform.position, this.transform.rotation);
            UnitRagDoll ragDoll = ragdollTransform.GetComponent<UnitRagDoll>();
            ragDoll.SetupRagDoll(originalRootBoneTransform);
        }
    }
}

