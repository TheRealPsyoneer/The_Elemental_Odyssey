using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Attack/Attack Stats SO"), fileName = ("New Attack Stats"))]
public class AttackStats : ScriptableObject
{
    public float damage;
    public float duration;
    public float speed;
    public float cooldown;

    
}
