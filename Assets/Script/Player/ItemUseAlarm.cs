using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseAlarm : MonoBehaviour
{
    public Action<IUseableObject> onUseableItemUsed;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject);
        Transform target = other.transform;
        
        IUseableObject item = other.GetComponent<IUseableObject>();
        if(item != null)
        {
            onUseableItemUsed?.Invoke(item);
        }

        IUseableObject obj = target.GetComponent<IUseableObject>();
        if(obj != null)
        {
            onUseableItemUsed?.Invoke(obj);
        }

    }
}
