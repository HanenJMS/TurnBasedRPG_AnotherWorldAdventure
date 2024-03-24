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
}
