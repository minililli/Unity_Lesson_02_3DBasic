using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(DoorManual))]
public class DoorKey : MonoBehaviour
{
    public DoorBase targetDoor;
    public float rotateSpeed = 360.0f;

    Transform keyModel;

    public bool isDirectUse => false;

    void Awake()
    {
        keyModel = transform.GetChild(0);
    }

    void Update()
    {
        keyModel.Rotate(Time.deltaTime * rotateSpeed * Vector3.up);
    }
  
    private void OnTriggerEnter(Collider other)
    {
        OnConsume();
    }

    private void OnValidate()
    {
        //Debug.Log("OnValidate");
        if (targetDoor != null)
        {
            // target이 자동문이어야 한다.
            // DoorAuto이면 그대로
            // DoorAuto가 아니면 target은 null.

            targetDoor = targetDoor as DoorAuto;

            //target = target.GetComponent<DoorAuto>(); // 위와 같은 기능의 코드

            //bool isDoorAuto = target is DoorAuto;     // 위와 같은 기능의 코드
            //if(!isDoorAuto)
            //{
            //    target = null;
            //}
        }
    }

    protected virtual void OnConsume()
    {
        targetDoor.Open();
        Destroy(this.gameObject);
    }

}
