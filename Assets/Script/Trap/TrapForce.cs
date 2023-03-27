using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapForce: TrapBase
{
    Animator anim;
    public float forcePower = 10.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    protected override void OnTrapActivate(GameObject target)
    {
        base.OnTrapActivate(target);
        Player player = target.GetComponent<Player>();
        anim.SetBool("onActivate", true);
        if (player != null)
        {
            Vector3 dir = (transform.forward + transform.up).normalized;
            player.Rigid.AddForce( dir * forcePower, ForceMode.Impulse);
            player.SetForceJumpMode();
        }
    }

}
