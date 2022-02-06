using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    public bool isOnCooldown;

    private float cooldownTime;
    private float completionTime;
    private float startTime;
    public bool HasPassed()
    {
        bool result = Time.time >= completionTime;
        isOnCooldown = false;
        return result;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
        completionTime = startTime + cooldownTime;
        isOnCooldown = true;
    }

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
        isOnCooldown = false;
    }

    public void ChangeCooldownByAmmount(float ammount)
    {
        completionTime += ammount;
    }
}
