using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats SO")]
public class PlayerStats : ScriptableObject
{
    public float walkSpeed;
    public float attackComboWaitTime;
    public int maxCombo;
}
