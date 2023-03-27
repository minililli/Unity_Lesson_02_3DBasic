using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFireEffect : TrapFire
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = FindObjectOfType<Player>();
        player.Die();
    }
}
