using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAuto : DoorBase
{

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                OnOpen();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnClose();
    }

}
