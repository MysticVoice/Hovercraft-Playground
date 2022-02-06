using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckableTimer : MonoBehaviour
{
    public float duration;
    private float startTime;
    bool detonateOnDestroy;
    [SerializeField] private UnityEvent onTimerEnd = new UnityEvent();

    private void OnDestroy()
    {
        if(detonateOnDestroy)
        {
            onTimerEnd?.Invoke();
            StopAllCoroutines();
        }
    }
    public float CheckTimer()
    {
        return startTime - Time.time;
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);
        onTimerEnd?.Invoke();
    }
    [ContextMenu("Start Timer")]
    public void StartTime()
    {
        StartCoroutine(StartTimer());
    }
    public void EndEarly()
    {
        onTimerEnd?.Invoke();
        StopAllCoroutines();
    }
    void Start()
    {
        startTime = 0;
    }
}
