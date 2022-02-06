using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateTimer : MonoBehaviour,ICheckableTimer
{
    public float duration { get; set; }
    private float startTime;
    [SerializeField] private UnityEvent onTimerEnd = new UnityEvent();

    
    public float CheckTimer()
    {
        return startTime - Time.time;
    }

    public IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);
        startTime = Time.time;
        onTimerEnd.Invoke();
    }

    void Start()
    {
        startTime = 0;
    }
}
