using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapSlow : TrapBase
{
    public float slowDuration = 5.0f;
  
    protected override void OnTrapActivate(GameObject target)
    {
        base.OnTrapActivate(target);
        Player player = target.GetComponent<Player>();
        if (player != null)
        {
            player.SetHalfSpeed();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player!= null)
            {
               StartCoroutine(RestoreSpeed(player));    
            }
        }
    }

    IEnumerator RestoreSpeed(Player player)
    {
        yield return new WaitForSeconds(slowDuration);
        player.ResetMoveSpeed();
    }
    
    
    
    

    
    
    
    
    
}
