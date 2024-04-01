using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPortraitUI : MonoBehaviour
{
    [SerializeField] SpriteRenderer portraitImage;

    private void Awake()
    {
        portraitImage = GetComponentInChildren<SpriteRenderer>();
    }
    private void LateUpdate()
    {
        this.transform.forward = (Camera.main.transform.forward);
    }
}
