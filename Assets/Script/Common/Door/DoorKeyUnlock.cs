using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyUnlock : DoorKey
{
    Action onConSume;

    bool getKey = false;

    private void Start()
    {
        ResetTarget();
    }

    private void OnValidate()
    {
        ResetTarget();
    }

    void ResetTarget()
    {
        if(targetDoor != null)
        {
            DoorAutoLock lockDoor = targetDoor as DoorAutoLock;
            if(lockDoor != null)
            {
                onConSume = lockDoor.Unlock;
            }
            else
            {
                targetDoor = null;
            }
        }
    }

    protected override void OnConsume()
    {
        onConSume?.Invoke();
        Destroy(gameObject);
    }
}
