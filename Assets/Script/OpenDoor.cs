using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : DoorBase
{
    Collider triggerBox;
    protected void Start()
    {
        triggerBox = GetComponent<Collider>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
        }
    }

}
