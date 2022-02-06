using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.InputSystem;

public class InputToFloat : ScriptableObject
{
    public InputActionProperty inputAction;
    public FloatReference floatOutput;

    private void ReactOnChanged()
    {

    }
}
