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
        
        while(target.parent !=null)
        {
            target = target.parent;
        }    

        ///사용 가능한 아이템인지 확인 (IUseableObject 인터페이스가 있다. == 사용가능한 오브젝트이다.)
        IUseableObject obj = target.GetComponent<IUseableObject>();
        if(obj != null)
        {
            onUseableItemUsed?.Invoke(obj);               //사용 가능한 오브젝트니까 알람을 보냄.
        }

    }
}
