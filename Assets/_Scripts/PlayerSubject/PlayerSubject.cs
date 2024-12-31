using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Subject SO", fileName = "New Player Subject")]
public class PlayerSubject : ScriptableObject
{
    public event Action<PlayerControl> playerActed;

    public void Broadcast(PlayerControl player)
    {
        playerActed?.Invoke(player);
    }
}
