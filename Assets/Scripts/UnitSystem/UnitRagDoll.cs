using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRagDoll : MonoBehaviour
{


    [SerializeField] Transform ragDollRootBone;

    public void SetupRagDoll(Transform origin)
    {
        MatchAllChildTransforms(origin, ragDollRootBone);
    }
    void MatchAllChildTransforms(Transform root, Transform clone)
    {
        foreach (Transform child in root)
        {
            Transform cloneChild = clone.Find(child.name);
            if (cloneChild != null)
            {
                cloneChild.position = child.position;
                cloneChild.rotation = child.rotation;
                MatchAllChildTransforms(child, cloneChild);
            }
        }
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyRagdoll());
    }

    private IEnumerator DestroyRagdoll()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
