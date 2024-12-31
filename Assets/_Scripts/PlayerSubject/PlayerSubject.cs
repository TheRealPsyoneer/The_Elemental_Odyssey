using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Subject SO", fileName = "New Player Subject")]
public class PlayerSubject : ScriptableObject
{
    public event Action<UnitControl> playerActed;

    public void Broadcast(UnitControl player)
    {
        playerActed?.Invoke(player);
    }
}
