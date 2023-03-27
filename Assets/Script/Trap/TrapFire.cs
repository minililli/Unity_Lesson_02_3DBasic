using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFire : TrapBase
{
    ParticleSystem ps;
    Transform child;
    public WaitForSeconds waitTime;

    private void Awake()
    {   
        child = transform.GetChild(1);
        ps=child.GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        waitTime = new WaitForSeconds(2.0f);
        ps.Stop();
        child.GetComponent<CapsuleCollider>().enabled = false;
    }
    protected override void OnTrapActivate(GameObject target)
    {
        base.OnTrapActivate(target);
        StartCoroutine(onFire());
    }

    IEnumerator onFire()
    {
        yield return waitTime;
        ps.Play();
        child.GetComponent<CapsuleCollider>().enabled = true;
    }
}
