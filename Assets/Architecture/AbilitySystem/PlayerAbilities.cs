using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Ability ability;
    public void UseAbility()
    {
        ability.Use(transform);
    }
}
