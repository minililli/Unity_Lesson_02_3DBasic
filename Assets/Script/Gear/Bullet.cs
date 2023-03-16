using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{   
    /// <summary>
    /// 시작이동속도
    /// </summary>
    public float initialSpeed = 30.0f;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rigid.velocity = transform.forward* initialSpeed ;    //초기운동량 설정
        //Debug.Log(rigid.velocity);
        StartCoroutine(LifeOver(10.0f));                       //비활성화
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(LifeOver(2.0f));                 //2초후 비활성화
    }


}
