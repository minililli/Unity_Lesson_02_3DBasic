using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour
{
    protected Animator anim;
    protected virtual void Awake()
    {
        Animator anim = GetComponent<Animator>();
    }
}
