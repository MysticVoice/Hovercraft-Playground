using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimer
{
    float duration { get; set; }
    IEnumerator StartTimer();
}
