using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBomb : TestBase
{
    public GameObject prefab;
    public float explosionForce = 100.0f;
    public float radius=20.0f;
    public float upward=1.0f;
    protected override void Test1(InputAction.CallbackContext _)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f); // 반경 2.0f 에 구 안에 들어오는 물체들
        Rigidbody[] rigids = new Rigidbody[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            rigids[i] = colliders[i].GetComponent<Rigidbody>();
        }

        foreach (Rigidbody rigid in rigids)
        {
            if (rigid != null)
            {
                rigid.AddExplosionForce(100.0f, transform.position, radius, upward, ForceMode.Impulse);
            }
        }
    }

    protected override void Test2(InputAction.CallbackContext _)
    {
        
    }
}
