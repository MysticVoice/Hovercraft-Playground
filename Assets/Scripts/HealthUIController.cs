using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityAtoms.BaseAtoms;

public class HealthUIController : MonoBehaviour
{
    private Image im;
    private RectTransform rt;
    public float sizeMultiplier = 200f;
    public IntReference health;
    public IntReference maxHealth;


    void Start()
    {
        im = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(normalize()*sizeMultiplier,rt.sizeDelta.y);
    }


    public float normalize()
    {
        return health.Value / (float)maxHealth.Value;
    }
}
