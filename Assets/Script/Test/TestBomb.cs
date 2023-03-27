using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBomb : TestBase
{
    protected override void Test1(InputAction.CallbackContext _)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f);
        Rigidbody[] rigids = new Rigidbody[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            rigids[i] = colliders[i].GetComponent<Rigidbody>();
        }

        foreach(Rigidbody rigid in rigids)
        {
            rigid.AddExplosionForce()
        }
    }
}
