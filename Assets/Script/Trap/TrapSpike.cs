using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapSpike : TrapBase
{
    Animator anim;
    Player player;
    public WaitForSeconds waitTime;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }
    protected override void OnTrapActivate(GameObject target)
    {
        base.OnTrapActivate(target);
        anim.SetBool("Pop", true);
    }

  /*  private void OnEnable()
    {
        waitTime = new WaitForSeconds(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pop());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Pop",false);
        StopCoroutine(Pop());
    }
    IEnumerator Pop()
    {
        yield return waitTime;
        anim.SetBool("Pop",true);
    }*/
}
