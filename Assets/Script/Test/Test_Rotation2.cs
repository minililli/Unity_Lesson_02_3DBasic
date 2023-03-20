using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Rotation2 : TestBase
{
    public Transform objBase;
    public Transform objChild1;
    public Transform objChild2;

    Quaternion to = Quaternion.LookRotation(Vector3.right, Vector3.up);
    protected override void Test1(InputAction.CallbackContext _)
    {
        Quaternion q = Quaternion.identity;
        objBase.rotation = q;
        objChild1.rotation = q;
        
        //objChild2.rotation = Quaternion.Euler(0,90,0); // y축으로 90도(degree)만큼 회전하는 쿼터니언 만들기
        //위의 Euler와 가능 기능을 하는 코드를 작성하기
        //1) Quaternion.AngleAxis
        Quaternion r = Quaternion.AngleAxis(90, Vector3.up);
        objChild2.rotation = r;
    }
    
    protected override void Test2(InputAction.CallbackContext _)
    {
        //.inverse : 뒤집기
        Quaternion q = Quaternion.Inverse(objChild2.rotation);
        objChild2.rotation *= q;
    }
    protected override void Test3(InputAction.CallbackContext _)
    {
        // .RotateToward : from회전에서 to회전으로 maxDegreeDelta만큼 회전시키기. 일정한 속도로 회전.
        objBase.rotation = Quaternion.RotateTowards(objBase.rotation, to, 90);

    }
    protected override void Test4(InputAction.CallbackContext _)
    {
        //Slerp : a회전에서 b회전으로 진행된다고할때 절반(0.5f)만큼 진행되었을 때의 회전 구하기
        Quaternion a = Quaternion.LookRotation(Vector3.forward);
        Quaternion b = Quaternion.LookRotation(Vector3.right);

        objBase.rotation = Quaternion.Slerp(a, b, 0.5f);
    }

    private void Update()
    {
        //objBase.rotation = Quaternion.RoateTowards(objBase.rotation, to, Time.deltaTime * 90.0f);
        objBase.rotation = Quaternion.Slerp(objBase.rotation,to, Time.deltaTime * 0.5f); // 천천히 브레이크 잡힘. 오~
       /* if (objBase.position.y < 1)
        {
            objBase.position.y = 0.0f;
        }*/
    }




}
