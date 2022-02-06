using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hover Settings",menuName = "Settings/Hover Settings")]
public class HoverSettings : SingletonScriptableObject<HoverSettings>
{
    [SerializeField]
    public LayerMask hoverRaycastMask;
}
