using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(DoorManual))]
public class DoorKey : MonoBehaviour, IUseableObject 
{
    DoorManual ManualDoor;
    Player player;
    Animator anim;

    bool getKey = false;
   
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        ManualDoor = FindObjectOfType<DoorManual>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ManualDoor != null)
        {
            if(other.CompareTag("Player"))
            {
                Debug.Log("들어옴");
                Used();
            }

        }
    }

    public Action<bool> GetKey;
    public void Used()
    {
        Destroy(this.gameObject);
        getKey = true;
        GetKey?.Invoke(getKey);
    }

}
